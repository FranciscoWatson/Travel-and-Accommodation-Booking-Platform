using TABP.Domain.Entities;

namespace TABP.Application.Interfaces.Repositories;

public interface IUserRoleRepository
{
    public Task<UserRole?> GetByIdAsync(Guid id);
    public Task<List<UserRole>> GetAllAsync();
    public Task<UserRole> CreateAsync(UserRole userRole);
    public Task UpdateAsync(UserRole userRole);
    public Task DeleteAsync(Guid id);
}