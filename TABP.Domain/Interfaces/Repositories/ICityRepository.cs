using TABP.Domain.Entities;
using TABP.Domain.Models;

namespace TABP.Domain.Interfaces.Repositories;

public interface ICityRepository
{
    Task<City?> GetByIdAsync(Guid id);
    Task<List<City>> GetAllAsync();
    Task<City> CreateAsync(City city);
    Task UpdateAsync(City city);
    Task DeleteAsync(Guid id);
    Task<List<TrendingCity>> GetTrendingCities(int count);
}