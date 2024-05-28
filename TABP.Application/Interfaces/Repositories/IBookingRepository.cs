using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(Guid id);
    Task<Booking?> GetByIdDetailedAsync(Guid id);
    Task<List<Booking>> GetAllAsync();
    Task<Booking> CreateAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(Guid id);
}