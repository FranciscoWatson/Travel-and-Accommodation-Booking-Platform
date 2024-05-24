using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;
using TABP.Domain.Models;

namespace TABP.Infrastructure.Persistence.Repositories;

public class CityRepository : ICityRepository
{
    private readonly TabpDbContext _context;

    public CityRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<City?> GetByIdAsync(Guid id)
    {
        return await _context.Cities.FindAsync(id);
    }

    public async Task<List<City>> GetAllAsync()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task<City> CreateAsync(City city)
    {
        await _context.Cities.AddAsync(city);
        await _context.SaveChangesAsync();
        return city;
    }

    public async Task UpdateAsync(City city)
    {
        _context.Cities.Update(city);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var city = new City { CityId = id };
        _context.Cities.Attach(city);
        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<TrendingCity>> GetTrendingCities(int count)
    {
        var trendingCities = await _context.Cities
            .Select(c => new TrendingCity
            {
                CityId = c.CityId,
                CityName = c.Name,
                VisitsCount = c.Hotels.SelectMany(h => h.RoomTypes)
                    .SelectMany(rt => rt.Rooms)
                    .SelectMany(r => r.BookingRooms)
                    .Select(br => br.Booking)
                    .Distinct()
                    .Count()
            })
            .OrderByDescending(c => c.VisitsCount)
            .Take(count)
            .ToListAsync();

        return trendingCities;
    }
}