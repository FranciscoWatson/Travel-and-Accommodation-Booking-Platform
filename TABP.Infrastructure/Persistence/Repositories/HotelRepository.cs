using Microsoft.EntityFrameworkCore;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Interfaces.Repositories;
using TABP.Application.Queries.Hotels;
using TABP.Domain.Entities;
using TABP.Domain.Models;

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
        query = query.Where(h =>
            h.RoomTypes.Any(roomType =>
                roomType.Name == request.RoomType &&
                roomType.AdultsCapacity >= request.NumberOfAdults &&
                roomType.ChildrenCapacity >= request.NumberOfChildren &&
                (request.MaxPrice == null || roomType.Price <= request.MaxPrice)
            )
        );

        query = query.Where(h =>
            h.RoomTypes.Any(rt =>
                rt.Rooms.Count(room => room.BookingRooms.All(br =>
                    (br.Booking.CheckIn > request.CheckOut || br.Booking.CheckOut < request.CheckIn)
                )) >= request.NumberOfRooms)
        );

        return query;
    }
    
    public async Task<List<FeaturedDeal>> GetHotelsWithActiveDiscounts(int count)
    {
        var currentDate = DateTime.UtcNow;

        var featuredDeals = await _context.Hotels
            .Include(h => h.City)
            .Include(h => h.RoomTypes)
            .ThenInclude(rt => rt.Discounts)
            .Where(h => h.RoomTypes.Any(rt => rt.Discounts.Any(d => d.StartDate <= currentDate && d.EndDate >= currentDate)))
            .Take(count)
            .Select(hotel => new FeaturedDeal
            {
                HotelId = hotel.HotelId,
                HotelName = hotel.Name,
                CityName = hotel.City.Name,
                StarRating = hotel.StarRating,
                ThumbnailUrl = hotel.HotelImages.FirstOrDefault().Url,
                DiscountPercentage = hotel.RoomTypes
                        .SelectMany(rt => rt.Discounts)
                        .Where(d => d.StartDate <= currentDate && d.EndDate >= currentDate)
                        .Max(d => d.Percentage),
                OriginalPrice = hotel.RoomTypes.Min(rt => rt.Price),
                DiscountedPrice = hotel.RoomTypes
                    .SelectMany(rt => rt.Discounts)
                    .Where(d => d.StartDate <= currentDate && d.EndDate >= currentDate)
                    .Max(d => 1 - (decimal)(d.Percentage / 100)) * hotel.RoomTypes.Min(rt => rt.Price)
            })
            .ToListAsync();

        return featuredDeals;
    }
}