using TABP.Domain.Entities;
using TABP.Domain.Models;

namespace TABP.Application.Interfaces.Repositories;

public interface IRoomTypeRepository
{
    Task<RoomType?> GetByIdAsync(Guid id);
    Task<List<RoomType>> GetAllAsync();
    Task<RoomType> CreateAsync(RoomType roomType);
    Task UpdateAsync(RoomType roomType);
    Task DeleteAsync(Guid id);
    Task<List<AvailableRoomTypes>> GetAvailableRoomTypesAsync(Guid hotelId, DateTime checkIn, DateTime checkOut);
}