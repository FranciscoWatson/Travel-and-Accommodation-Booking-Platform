using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IDiscountRepository
{
    Task<Discount?> GetByIdAsync(Guid id);
    Task<List<Discount>> GetAllAsync();
    Task<Discount> CreateAsync(Discount discount);
    Task UpdateAsync(Discount discount);
    Task DeleteAsync(Guid id);
    Task<List<Discount>> GetActiveDiscountsByRoomTypeIdAsync(Guid roomTypeId, DateTime checkIn, DateTime checkOut);
}