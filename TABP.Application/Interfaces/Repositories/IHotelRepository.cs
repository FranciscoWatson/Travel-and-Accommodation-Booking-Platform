using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IHotelRepository
{
    public Task<Hotel?> GetByIdAsync(Guid id);
    public Task<List<Hotel>> GetAllAsync();
    public Task<Hotel> CreateAsync(Hotel hotel);
    public Task UpdateAsync(Hotel hotel);
    public Task DeleteAsync(Guid id);
}