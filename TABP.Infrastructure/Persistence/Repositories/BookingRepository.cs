using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly TabpDbContext _context;

    public BookingRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<Booking?> GetByIdAsync(Guid id)
    {
        return await _context.Bookings.FindAsync(id);
    }
    
    public async Task<Booking?> GetByIdDetailedAsync(Guid id)
    {
        return await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.BookingRooms).ThenInclude(br => br.Room).ThenInclude(r => r.RoomType)
            .Include(b => b.Payment)
            .SingleOrDefaultAsync(b => b.BookingId == id);
    }
    
    public async Task<List<Booking>> GetAllAsync()
    {
        return await _context.Bookings.ToListAsync();
    }

    public async Task<Booking> CreateAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task UpdateAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var booking = new Booking { BookingId = id };
        _context.Bookings.Attach(booking);
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
    }
}