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

    public async Task<List<Hotel>> SearchAndFilterHotelsAsync(SearchAndFilterHotelsQuery request)
    {
        IQueryable<Hotel> query = _context.Hotels
            .Include(h => h.HotelAmenities).ThenInclude(ha => ha.Amenity)
            .Include(h => h.HotelImages)
            .Include(h => h.City)
            .Include(h => h.Rooms).ThenInclude(r => r.RoomType)
            .Include(h => h.Rooms).ThenInclude(r => r.BookingRooms).ThenInclude(br => br.Booking)
            .AsSplitQuery();

        query = FilterByHotelName(query, request.HotelName);
        query = FilterByCity(query, request.City);
        query = FilterByRating(query, request.MinRating);
        query = FilterByRoomsAndAvailability(query, request);
        
        return await query.ToListAsync();
    }
    
    private IQueryable<Hotel> FilterByHotelName(IQueryable<Hotel> query, string? hotelName)
    {
        return string.IsNullOrWhiteSpace(hotelName) ? query : query.Where(h => h.Name.Contains(hotelName));
    }

    private IQueryable<Hotel> FilterByCity(IQueryable<Hotel> query, string? city)
    {
        return string.IsNullOrWhiteSpace(city) ? query : query.Where(h => h.City.Name == city);
    }

    private IQueryable<Hotel> FilterByRating(IQueryable<Hotel> query, int? minRating)
    {
        return minRating == null ? query : query.Where(h => h.StarRating >= minRating.Value);
    } 
    
    private IQueryable<Hotel> FilterByRoomsAndAvailability(IQueryable<Hotel> query, SearchAndFilterHotelsQuery request)
    {
        return query.Where(h => h.Rooms
            .Count(r => !r.BookingRooms.Any(br => br.Booking.CheckIn < request.CheckOut && br.Booking.CheckOut > request.CheckIn)
                        && r.AdultsCapacity >= request.NumberOfAdults
                        && r.ChildrenCapacity >= request.NumberOfChildren
                        && (request.MaxPrice == null || r.Price <= request.MaxPrice)
                        && (request.RoomType == null || r.RoomType.Name.Equals(request.RoomType))) >= request.NumberOfRooms);
    }
}