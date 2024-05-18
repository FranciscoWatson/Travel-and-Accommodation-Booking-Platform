using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly TabpDbContext _context;

    public CountryRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<Country?> GetByIdAsync(Guid id)
    {
        return await _context.Countries.FindAsync(id);
    }

    public async Task<List<Country>> GetAllAsync()
    {
        return await _context.Countries.ToListAsync();
    }

    public async Task<Country> CreateAsync(Country country)
    {
        await _context.Countries.AddAsync(country);
        await _context.SaveChangesAsync();
        return country;
    }

    public async Task UpdateAsync(Country country)
    {
        _context.Countries.Update(country);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var country = new Country { CountryId = id };
        _context.Countries.Attach(country);
        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();
    }
}