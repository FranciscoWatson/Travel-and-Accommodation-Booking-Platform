using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Domain.Entities;
using TABP.Domain.Models;

namespace TABP.Application.Interfaces.Repositories;

public interface IHotelRepository
{
    public Task<Hotel?> GetByIdAsync(Guid id);
    public Task<List<Hotel>> GetAllAsync();
    public Task<List<Hotel>> GetAllWithFullDetailsAsync();
    public Task<Hotel> CreateAsync(Hotel hotel);
    public Task UpdateAsync(Hotel hotel);
    public Task DeleteAsync(Guid id);
    public Task<List<HotelSearch>> SearchAndFilterHotelsAsync(SearchAndFilterHotelsQuery request);
    public Task<List<FeaturedDeal>> GetHotelsWithActiveDiscounts(int count);
}