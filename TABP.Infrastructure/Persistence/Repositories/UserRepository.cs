using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;
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
        var bookings = await _context.Users
            .Where(u => u.UserId == userId)
            .SelectMany(u => u.Bookings)
            .Select(b => new
            {
                HotelId = b.BookingRooms.First().Room.RoomType.Hotel.HotelId,
                HotelName = b.BookingRooms.First().Room.RoomType.Hotel.Name,
                CheckOut = b.CheckOut,
                TotalPrice = b.PriceAtBooking,
                CityName = b.BookingRooms.First().Room.RoomType.Hotel.City.Name,
                StarRating = b.BookingRooms.First().Room.RoomType.Hotel.StarRating,
                ThumbnailImage = b.BookingRooms.First().Room.RoomType.Hotel.HotelImages.First().Url
                
            })
            .OrderByDescending(b => b.CheckOut)
            .ToListAsync();

        var recentlyVisitedHotels = bookings
            .GroupBy(b => b.HotelId)
            .Select(g => new RecentlyVisitedHotel
            {
                HotelId = g.Key,
                HotelName = g.First().HotelName,
                PricePaid = g.First().TotalPrice,
                LastVisited = g.First().CheckOut,
                CityName = g.First().CityName,
                ThumbnailImage = g.First().ThumbnailImage,
                StarRating = g.First().StarRating
            })
            .OrderByDescending(h => h.LastVisited)
            .Take(count)
            .ToList();

        return recentlyVisitedHotels;
    }
}