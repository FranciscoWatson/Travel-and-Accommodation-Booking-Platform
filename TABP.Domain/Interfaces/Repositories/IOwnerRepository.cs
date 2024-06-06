using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces.Repositories;

public interface IOwnerRepository
{
    public Task<Owner?> GetByIdAsync(Guid id);
    public Task<List<Owner>> GetAllAsync();
    public Task<Owner> CreateAsync(Owner owner);
    public Task UpdateAsync(Owner owner);
    public Task DeleteAsync(Guid id);
    public Task<bool> ExistsAsync(Guid id);
}