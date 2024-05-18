using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class AmenityRepository : IAmenityRepository
{
    private readonly TabpDbContext _context;

    public AmenityRepository(TabpDbContext context)
    {
        _context = context;
    }
    
    public async Task<Amenity?> GetByIdAsync(Guid id)
    {
        return await _context.Amenities.FindAsync(id);
    }

    public async Task<List<Amenity>> GetAllAsync()
    {
        return await _context.Amenities.ToListAsync();
    }

    public async Task<Amenity> CreateAsync(Amenity amenity)
    {
        await _context.Amenities.AddAsync(amenity);
        await _context.SaveChangesAsync();
        return amenity;
    }

    public async Task UpdateAsync(Amenity amenity)
    {
        _context.Amenities.Update(amenity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var amenity = new Amenity { AmenityId = id };
        _context.Amenities.Attach(amenity);
        _context.Amenities.Remove(amenity);
        await _context.SaveChangesAsync();
    }
}