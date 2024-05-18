using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class RoomDiscountRepository : IRoomDiscountRepository
{
    private readonly TabpDbContext _context;

    public RoomDiscountRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<RoomDiscount?> GetByIdAsync(Guid id)
    {
        return await _context.RoomDiscounts.FindAsync(id);
    }

    public async Task<List<RoomDiscount>> GetAllAsync()
    {
        return await _context.RoomDiscounts.ToListAsync();
    }

    public async Task<RoomDiscount> CreateAsync(RoomDiscount roomDiscount)
    {
        await _context.RoomDiscounts.AddAsync(roomDiscount);
        await _context.SaveChangesAsync();
        return roomDiscount;
    }

    public async Task UpdateAsync(RoomDiscount roomDiscount)
    {
        _context.RoomDiscounts.Update(roomDiscount);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var roomDiscount = new RoomDiscount { RoomDiscountId = id };
        _context.RoomDiscounts.Attach(roomDiscount);
        _context.RoomDiscounts.Remove(roomDiscount);
        await _context.SaveChangesAsync();
    }
}