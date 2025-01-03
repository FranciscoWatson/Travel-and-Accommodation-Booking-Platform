using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Infrastructure.Persistence.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly TabpDbContext _context;

    public DiscountRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<Discount?> GetByIdAsync(Guid id)
    {
        return await _context.Discounts.FindAsync(id);
    }

    public async Task<List<Discount>> GetAllAsync()
    {
        return await _context.Discounts.ToListAsync();
    }

    public async Task<Discount> CreateAsync(Discount discount)
    {
        await _context.Discounts.AddAsync(discount);
        await _context.SaveChangesAsync();
        return discount;
    }

    public async Task UpdateAsync(Discount discount)
    {
        _context.Discounts.Update(discount);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var discount = new Discount { DiscountId = id };
        _context.Discounts.Attach(discount);
        _context.Discounts.Remove(discount);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Discount>> GetActiveDiscountsByRoomTypeIdAsync(Guid roomTypeId, DateTime checkIn, DateTime checkOut)
    {
        return await _context.Discounts
            .Where(d => d.RoomTypeId == roomTypeId && d.StartDate <= checkIn && d.EndDate >= checkOut)
            .ToListAsync();
    }
}