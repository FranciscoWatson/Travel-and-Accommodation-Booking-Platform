using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly TabpDbContext _context;

    public RoomRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<Room?> GetByIdAsync(Guid id)
    {
        return await _context.Rooms.FindAsync(id);
    }

    public async Task<List<Room>> GetAllAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room> CreateAsync(Room room)
    {
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task UpdateAsync(Room room)
    {
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var room = new Room { RoomId = id };
        _context.Rooms.Attach(room);
        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Room>> GetAvailableRoomsByTypeIdAsync(Guid roomTypeId, DateTime checkIn, DateTime checkOut)
    {
        return await _context.Rooms
            .Where(r => r.RoomTypeId == roomTypeId && r.BookingRooms.All(br => br.Booking.CheckOut <= checkIn || br.Booking.CheckIn >= checkOut))
            .ToListAsync();
    }
}