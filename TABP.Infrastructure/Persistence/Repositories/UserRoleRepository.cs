using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly TabpDbContext _context;

    public UserRoleRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<UserRole?> GetByIdAsync(Guid id)
    {
        return await _context.UserRoles.FindAsync(id);
    }

    public async Task<List<UserRole>> GetAllAsync()
    {
        return await _context.UserRoles.ToListAsync();
    }

    public async Task<UserRole> CreateAsync(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
        await _context.SaveChangesAsync();
        return userRole;
    }

    public async Task UpdateAsync(UserRole userRole)
    {
        _context.UserRoles.Update(userRole);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var userRole = new UserRole { UserRoleId = id };
        _context.UserRoles.Attach(userRole);
        _context.UserRoles.Remove(userRole);
        await _context.SaveChangesAsync();
    }
}