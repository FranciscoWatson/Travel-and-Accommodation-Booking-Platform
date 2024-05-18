using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TabpDbContext _context;

    public UserRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = new User { UserId = id };
        _context.Users.Attach(user);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}