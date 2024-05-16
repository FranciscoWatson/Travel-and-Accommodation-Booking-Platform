using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IRoomRepository
{
    public Task<Room?> GetByIdAsync(Guid id);
    public Task<List<Room>> GetAllAsync();
    public Task<Room> CreateAsync(Room room);
    public Task UpdateAsync(Room room);
    public Task DeleteAsync(Guid id);
}