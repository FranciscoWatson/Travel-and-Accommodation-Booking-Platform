using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface ICityRepository
{
    public Task<City?> GetByIdAsync(Guid id);
    public Task<List<City>> GetAllAsync();
    public Task<City> CreateAsync(City city);
    public Task UpdateAsync(City city);
    public Task DeleteAsync(Guid id);
}