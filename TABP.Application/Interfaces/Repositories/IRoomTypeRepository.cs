using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IRoomTypeRepository
{
    public Task<RoomType?> GetByIdAsync(Guid id);
    public Task<List<RoomType>> GetAllAsync();
    public Task<RoomType> CreateAsync(RoomType roomType);
    public Task UpdateAsync(RoomType roomType);
    public Task DeleteAsync(Guid id);
}