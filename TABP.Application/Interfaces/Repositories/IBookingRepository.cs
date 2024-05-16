using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IBookingRepository
{
    public Task<Booking?> GetByIdAsync(Guid id);
    public Task<List<Booking>> GetAllAsync();
    public Task<Booking> CreateAsync(Booking booking);
    public Task UpdateAsync(Booking booking);
    public Task DeleteAsync(Guid id);
}