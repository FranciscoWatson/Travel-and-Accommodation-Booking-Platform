using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces.Repositories;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(Guid id);
    Task<List<Room>> GetAllAsync();
    Task<Room> CreateAsync(Room room);
    Task UpdateAsync(Room room);
    Task DeleteAsync(Guid id);
    Task<List<Room>> GetAvailableRoomsByTypeIdAsync(Guid roomTypeId, DateTime checkIn, DateTime checkOut);
    Task<Room?> GetByIdAdminAsync(Guid roomId);
}