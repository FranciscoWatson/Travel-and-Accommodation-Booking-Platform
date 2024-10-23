using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces.Repositories;

public interface IAmenityRepository
{
    public Task<Amenity?> GetByIdAsync(Guid id);
    public Task<List<Amenity>> GetAllAsync();
    public Task<Amenity> CreateAsync(Amenity amenity);
    public Task UpdateAsync(Amenity amenity);
    public Task DeleteAsync(Guid id);
}