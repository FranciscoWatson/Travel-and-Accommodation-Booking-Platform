using TABP.Domain.Entities;
using TABP.Domain.Models;

namespace TABP.Application.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<User?> GetByIdAsync(Guid id);
    public Task<List<User>> GetAllAsync();
    public Task<User> CreateAsync(User user);
    public Task UpdateAsync(User user);
    public Task DeleteAsync(Guid id);
    Task<List<RecentlyVisitedHotel>> GetRecentlyVisitedHotelsAsync(Guid id, int count);
}