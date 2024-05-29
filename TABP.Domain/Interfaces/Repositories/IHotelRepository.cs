using TABP.Domain.Entities;
using TABP.Domain.Models;

namespace TABP.Domain.Interfaces.Repositories;

public interface IHotelRepository
{
    public Task<Hotel?> GetByIdAsync(Guid id);
    public Task<List<Hotel>> GetAllAsync();
    public Task<List<Hotel>> GetAllWithFullDetailsAsync();
    public Task<Hotel> CreateAsync(Hotel hotel);
    public Task UpdateAsync(Hotel hotel);
    public Task DeleteAsync(Guid id);
    public Task<List<HotelSearch>> SearchAndFilterHotelsAsync(IHotelSearchCriteria request);
    public Task<List<FeaturedDeal>> GetFeaturedDealsAsync(int count);
}