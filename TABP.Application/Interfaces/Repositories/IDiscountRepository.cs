using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IDiscountRepository
{
    public Task<Discount?> GetByIdAsync(Guid id);
    public Task<List<Discount>> GetAllAsync();
    public Task<Discount> CreateAsync(Discount discount);
    public Task UpdateAsync(Discount discount);
    public Task DeleteAsync(Guid id);
}