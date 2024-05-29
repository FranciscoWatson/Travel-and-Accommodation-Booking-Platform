using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;
using TABP.Domain.Models;

namespace TABP.Infrastructure.Persistence.Repositories;

public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly TabpDbContext _context;

    public RoomTypeRepository(TabpDbContext context)
    {
        _context = context;
    }

    public async Task<RoomType?> GetByIdAsync(Guid id)
    {
        return await _context.RoomTypes.FindAsync(id);
    }

    public async Task<List<RoomType>> GetAllAsync()
    {
        return await _context.RoomTypes.ToListAsync();
    }

    public async Task<RoomType> CreateAsync(RoomType roomType)
    {
        await _context.RoomTypes.AddAsync(roomType);
        await _context.SaveChangesAsync();
        return roomType;
    }

    public async Task UpdateAsync(RoomType roomType)
    {
        _context.RoomTypes.Update(roomType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var roomType = new RoomType { RoomTypeId = id };
        _context.RoomTypes.Attach(roomType);
        _context.RoomTypes.Remove(roomType);
        await _context.SaveChangesAsync();
    }
    

    public async Task<List<AvailableRoomTypes>> GetAvailableRoomTypesAsync(Guid hotelId, DateTime checkIn, DateTime checkOut)
    {
        var availableRoomTypes = await _context.RoomTypes
            .Where(rt => rt.HotelId == hotelId && rt.Rooms.Any(r =>
                !r.BookingRooms.Any(br => br.Booking.CheckIn < checkOut && br.Booking.CheckOut > checkIn)))
            .Select(rt => new AvailableRoomTypes
            {
                RoomTypeId = rt.RoomTypeId,
                Name = rt.Name,
                Price = rt.Price,
                DiscountedPrice = rt.Discounts
                    .Where(d => d.StartDate <= checkIn && d.EndDate >= checkOut)
                    .Select(d => (decimal?) (rt.Price * (1 - (decimal)(d.Percentage / 100))))
                    .FirstOrDefault() ?? rt.Price,
                Description = rt.Description,
                AdultsCapacity = rt.AdultsCapacity,
                ChildrenCapacity = rt.ChildrenCapacity,
                RoomImagesUrls = rt.RoomImages.Select(ri => ri.Url).ToList()
            })
            .ToListAsync();

        return availableRoomTypes;
    }
}