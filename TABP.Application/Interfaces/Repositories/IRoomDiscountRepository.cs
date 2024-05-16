using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IRoomDiscountRepository
{
    public Task<RoomDiscount?> GetByIdAsync(Guid id);
    public Task<List<RoomDiscount>> GetAllAsync();
    public Task<RoomDiscount> CreateAsync(RoomDiscount roomDiscount);
    public Task UpdateAsync(RoomDiscount roomDiscount);
    public Task DeleteAsync(Guid id);
}