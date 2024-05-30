using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

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

    public async Task<Room?> GetByIdAdminAsync(Guid roomId)
    {
        var room = await _context.Rooms
            .Include(r => r.RoomType)
            .Include(r => r.BookingRooms).ThenInclude(br => br.Booking)
            .FirstOrDefaultAsync(r => r.RoomId == roomId);
        return room;
    }
}