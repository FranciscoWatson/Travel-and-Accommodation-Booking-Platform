using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IPaymentRepository
{
    public Task<Payment?> GetByIdAsync(Guid id);
    public Task<List<Payment>> GetAllAsync();
    public Task<Payment> CreateAsync(Payment payment);
    public Task UpdateAsync(Payment payment);
    public Task DeleteAsync(Guid id);
}