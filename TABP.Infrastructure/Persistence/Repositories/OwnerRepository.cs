using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class OwnerRepository : IOwnerRepository
{
    private readonly TabpDbContext _context;

    public OwnerRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<Owner?> GetByIdAsync(Guid id)
    {
        return await _context.Owners.FindAsync(id);
    }

    public async Task<List<Owner>> GetAllAsync()
    {
        return await _context.Owners.ToListAsync();
    }

    public async Task<Owner> CreateAsync(Owner owner)
    {
        await _context.Owners.AddAsync(owner);
        await _context.SaveChangesAsync();
        return owner;
    }

    public async Task UpdateAsync(Owner owner)
    {
        _context.Owners.Update(owner);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var owner = new Owner { OwnerId = id };
        _context.Owners.Attach(owner);
        _context.Owners.Remove(owner);
        await _context.SaveChangesAsync();
    }
}