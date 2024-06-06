using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces.Repositories;

public interface ICountryRepository
{
    public Task<Country?> GetByIdAsync(Guid id);
    public Task<List<Country>> GetAllAsync();
    public Task<Country> CreateAsync(Country country);
    public Task UpdateAsync(Country country);
    public Task DeleteAsync(Guid id);
    public Task<bool> ExistsAsync(Guid id);
}