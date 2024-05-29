using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Infrastructure.Persistence.Repositories;

public class RoomImageRepository : IRoomImageRepository
{
    private readonly TabpDbContext _context;

    public RoomImageRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<RoomImage?> GetByIdAsync(Guid id)
    {
        return await _context.RoomImages.FindAsync(id);
    }

    public async Task<List<RoomImage>> GetAllAsync()
    {
        return await _context.RoomImages.ToListAsync();
    }

    public async Task<RoomImage> CreateAsync(RoomImage roomImage)
    {
        await _context.RoomImages.AddAsync(roomImage);
        await _context.SaveChangesAsync();
        return roomImage;
    }

    public async Task UpdateAsync(RoomImage roomImage)
    {
        _context.RoomImages.Update(roomImage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var roomImage = new RoomImage { RoomImageId = id };
        _context.RoomImages.Attach(roomImage);
        _context.RoomImages.Remove(roomImage);
        await _context.SaveChangesAsync();
    }
}