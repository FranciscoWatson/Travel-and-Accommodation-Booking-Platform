using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Criteria;
using TABP.Domain.Models;

namespace TABP.Domain.Interfaces.Repositories;

public interface IHotelRepository
{
    Task<Hotel?> GetByIdAsync(Guid id);
    Task<Hotel?> GetByIdAdminAsync(Guid id);
    Task<List<Hotel>> GetAllAsync();
    Task<List<Hotel>> GetAllForAdminAsync();
    Task<List<Hotel>> GetAllWithFullDetailsAsync();
    Task<Hotel> CreateAsync(Hotel hotel);
    Task UpdateAsync(Hotel hotel);
    Task DeleteAsync(Guid id);
    Task<List<HotelSearch>> SearchAndFilterHotelsAsync(IHotelSearchCriteria request);
    Task<List<FeaturedDeal>> GetFeaturedDealsAsync(int count);
    Task<bool> ExistsAsync(Guid id);
}