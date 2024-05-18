using Microsoft.EntityFrameworkCore;
using TABP.Application.Interfaces.Repositories;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistence.Repositories;

public class HotelImageRepository : IHotelImageRepository
{
private readonly TabpDbContext _context;

    public HotelImageRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<HotelImage?> GetByIdAsync(Guid id)
    {
        return await _context.HotelImages.FindAsync(id);
    }

    public async Task<List<HotelImage>> GetAllAsync()
    {
        return await _context.HotelImages.ToListAsync();
    }

    public async Task<HotelImage> CreateAsync(HotelImage hotelImage)
    {
        await _context.HotelImages.AddAsync(hotelImage);
        await _context.SaveChangesAsync();
        return hotelImage;
    }

    public async Task UpdateAsync(HotelImage hotelImage)
    {
        _context.HotelImages.Update(hotelImage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var hotelImage = new HotelImage { HotelImageId = id };
        _context.HotelImages.Attach(hotelImage);
        _context.HotelImages.Remove(hotelImage);
        await _context.SaveChangesAsync();
    }
}