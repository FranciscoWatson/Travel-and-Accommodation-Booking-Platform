using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IRoomImageRepository
{
    public Task<RoomImage?> GetByIdAsync(Guid id);
    public Task<List<RoomImage>> GetAllAsync();
    public Task<RoomImage> CreateAsync(RoomImage roomImage);
    public Task UpdateAsync(RoomImage roomImage);
    public Task DeleteAsync(Guid id);
}