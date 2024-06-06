using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;
using TABP.Domain.Models;

namespace TABP.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TabpDbContext _context;

    public UserRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = new User { UserId = id };
        _context.Users.Attach(user);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
    
   public async Task<List<RecentlyVisitedHotel>> GetRecentlyVisitedHotelsAsync(Guid userId, int count)
      {
          var recentlyVisitedHotels = await _context.Bookings
              .Include(b => b.BookingRooms)
              .ThenInclude(br => br.Room)
              .ThenInclude(r => r.RoomType)
              .ThenInclude(rt => rt.Hotel)
              .ThenInclude(h => h.City)
              .Where(b => b.UserId == userId)
              .SelectMany(b => b.BookingRooms)
              .GroupBy(br => br.Room.RoomType.Hotel.HotelId)
              .Select(g => new RecentlyVisitedHotel
              {
                  HotelId = g.Key,
                  HotelName = g.First().Room.RoomType.Hotel.Name,
                  PricePaid = g.OrderByDescending(br => br.Booking.CheckOut).First().Booking.PriceAtBooking,
                  LastVisited = g.Max(br => br.Booking.CheckOut),
                  ThumbnailImage = g.First().Room.RoomType.Hotel.ThumbnailUrl,
                  CityName = g.First().Room.RoomType.Hotel.City.Name,
                  StarRating = g.First().Room.RoomType.Hotel.StarRating
              })
              .OrderByDescending(h => h.LastVisited)
              .Take(count)
              .ToListAsync();

          return recentlyVisitedHotels;
      }
    
    public async Task<User?> AuthenticateAsync(string username, string password)
    {
        return await _context.Users
            .Include(u => u.UserRole)
            .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
    }
    
    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Users.AnyAsync(u => u.UserId == id);
    }
}