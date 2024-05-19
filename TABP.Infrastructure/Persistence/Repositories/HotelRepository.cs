using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly TabpDbContext _context;

    public HotelRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<Hotel?> GetByIdAsync(Guid id)
    {
        return await _context.Hotels.FindAsync(id);
    }

    public async Task<List<Hotel>> GetAllAsync()
    {
        return await _context.Hotels.ToListAsync();
    }
    public async Task<List<Hotel>> GetAllWithFullDetailsAsync()
    {
        return await _context.Hotels
            .Include(h => h.Amenities)
            .Include(h => h.Reviews)
            .Include(h => h.HotelImages)
            .Include(h => h.City)
            .Include(h => h.Owner)
            .ToListAsync();
    }

    public async Task<Hotel> CreateAsync(Hotel hotel)
    {
        await _context.Hotels.AddAsync(hotel);
        await _context.SaveChangesAsync();
        return hotel;
    }

    public async Task UpdateAsync(Hotel hotel)
    {
        _context.Hotels.Update(hotel);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var hotel = new Hotel { HotelId = id };
        _context.Hotels.Attach(hotel);
        _context.Hotels.Remove(hotel);
        await _context.SaveChangesAsync();
    }
}