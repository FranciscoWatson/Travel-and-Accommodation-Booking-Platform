using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces.Repositories;

public interface IHotelImageRepository
{
    public Task<HotelImage?> GetByIdAsync(Guid id);
    public Task<List<HotelImage>> GetAllAsync();
    public Task<HotelImage> CreateAsync(HotelImage hotelImage);
    public Task UpdateAsync(HotelImage hotelImage);
    public Task DeleteAsync(Guid id);
}