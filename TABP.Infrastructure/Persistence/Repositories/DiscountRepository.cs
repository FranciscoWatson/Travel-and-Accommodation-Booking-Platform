using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

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
}