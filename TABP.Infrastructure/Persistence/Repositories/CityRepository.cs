using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;
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
        var city = await _context.Cities
            .Include(c => c.Hotels)
            .Include(c => c.Country)
            .FirstOrDefaultAsync(c => c.CityId == id);
        return city;
    }

    public async Task<List<City>> GetAllAsync()
    {
        return await _context.Cities.Include(c => c.Hotels).ToListAsync();
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
                ThumbnailImage = c.ThumbnailImage,
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