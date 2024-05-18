using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly TabpDbContext _context;

    public RoomTypeRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<RoomType?> GetByIdAsync(Guid id)
    {
        return await _context.RoomTypes.FindAsync(id);
    }

    public async Task<List<RoomType>> GetAllAsync()
    {
        return await _context.RoomTypes.ToListAsync();
    }

    public async Task<RoomType> CreateAsync(RoomType roomType)
    {
        await _context.RoomTypes.AddAsync(roomType);
        await _context.SaveChangesAsync();
        return roomType;
    }

    public async Task UpdateAsync(RoomType roomType)
    {
        _context.RoomTypes.Update(roomType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var roomType = new RoomType { RoomTypeId = id };
        _context.RoomTypes.Attach(roomType);
        _context.RoomTypes.Remove(roomType);
        await _context.SaveChangesAsync();
    }
}