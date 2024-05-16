using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface ICountryRepository
{
    public Task<Country?> GetByIdAsync(Guid id);
    public Task<List<Country>> GetAllAsync();
    public Task<Country> CreateAsync(Country country);
    public Task UpdateAsync(Country country);
    public Task DeleteAsync(Guid id);
}