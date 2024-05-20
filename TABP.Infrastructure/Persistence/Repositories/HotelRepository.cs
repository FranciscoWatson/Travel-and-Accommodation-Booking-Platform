using Microsoft.EntityFrameworkCore;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Interfaces.Repositories;
using TABP.Application.Queries.Hotels;
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
            .Include(h => h.HotelAmenities).ThenInclude(ha => ha.Amenity)
            .Include(h => h.Reviews)
            .Include(h => h.HotelImages)
            .Include(h => h.City)
            .Include(h => h.Owner)
            .ToListAsync();
    }
    
    public async Task<List<Hotel>> SearchHotelsAsync(SearchHotelQuery request)
    {
        IQueryable<Hotel> query = _context.Hotels
            .Include(h => h.HotelImages)
            .Include(h => h.City)
            .Include(h => h.Rooms).ThenInclude(r => r.RoomType)
            .Include(h => h.Rooms).ThenInclude(r => r.BookingRooms).ThenInclude(br => br.Booking);

        query = FilterByRoomAvailability(query, request);
        query = ApplyGeneralHotelFilters(query, request);

        return await query.ToListAsync();
    }

    private IQueryable<Hotel> FilterByRoomAvailability(IQueryable<Hotel> query, SearchHotelQuery request)
    {
        return query.Where(h => h.Rooms.Any(r =>
            r.BookingRooms.Any(br =>
                (!request.MaxPrice.HasValue || r.Price <= request.MaxPrice) &&
                (br.Booking.CheckOut <= request.CheckIn || br.Booking.CheckIn >= request.CheckOut) &&
                r.AdultsCapacity >= request.NumberOfAdults &&
                r.ChildrenCapacity >= request.NumberOfChildren &&
                (!string.IsNullOrEmpty(request.RoomType) && r.RoomType.Name == request.RoomType))));
    }

    private IQueryable<Hotel> ApplyGeneralHotelFilters(IQueryable<Hotel> query, SearchHotelQuery request)
    {
        if (!string.IsNullOrEmpty(request.HotelName))
            query = query.Where(h => h.Name.Contains(request.HotelName));

        if (!string.IsNullOrEmpty(request.City))
            query = query.Where(h => h.City.Name.Contains(request.City));

        if (request.MinRating.HasValue)
            query = query.Where(h => h.StarRating >= request.MinRating);

        return query;
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