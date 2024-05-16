using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IHotelDiscountRepository
{
    public Task<HotelDiscount?> GetByIdAsync(Guid id);
    public Task<List<HotelDiscount>> GetAllAsync();
    public Task<HotelDiscount> CreateAsync(HotelDiscount hotelDiscount);
    public Task UpdateAsync(HotelDiscount hotelDiscount);
    public Task DeleteAsync(Guid id);
}