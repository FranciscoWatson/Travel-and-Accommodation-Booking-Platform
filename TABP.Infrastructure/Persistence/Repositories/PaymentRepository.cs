using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly TabpDbContext _context;

    public PaymentRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<Payment?> GetByIdAsync(Guid id)
    {
        return await _context.Payments.FindAsync(id);
    }

    public async Task<List<Payment>> GetAllAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task<Payment> CreateAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var payment = new Payment { PaymentId = id };
        _context.Payments.Attach(payment);
        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
    }
}