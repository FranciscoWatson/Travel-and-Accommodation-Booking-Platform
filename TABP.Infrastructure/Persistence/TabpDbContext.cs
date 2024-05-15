using Microsoft.EntityFrameworkCore;
using TABP.Domain.Entities;

namespace TABP.Infrastructure.Persistance;

public class TabpDbContext : DbContext
{
    public TabpDbContext(DbContextOptions<TabpDbContext> options) : base(options)
    {
    }
    
    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<HotelDiscount> HotelDiscounts { get; set; }
    public DbSet<HotelImage> HotelImages { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomDiscount> RoomDiscounts { get; set; }
    public DbSet<RoomImage> RoomImages { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Booking>()
            .Property(b => b.PriceAtBooking)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Payment>()
            .Property(p => p.Amount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Room>()
            .Property(r => r.Price)
            .HasColumnType("decimal(18,2)");
        
        
         modelBuilder.Entity<Amenity>()
        .Property(a => a.AmenityId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<Booking>()
        .Property(b => b.BookingId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<City>()
        .Property(c => c.CityId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<Country>()
        .Property(c => c.CountryId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<Hotel>()
        .Property(h => h.HotelId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<HotelDiscount>()
        .Property(hd => hd.HotelDiscountId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<HotelImage>()
        .Property(hi => hi.HotelImageId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<Owner>()
        .Property(o => o.OwnerId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<Payment>()
        .Property(p => p.PaymentId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<Review>()
        .Property(r => r.ReviewId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<Room>()
        .Property(r => r.RoomId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<RoomDiscount>()
        .Property(rd => rd.RoomDiscountId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<RoomImage>()
        .Property(ri => ri.RoomImageId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<RoomType>()
        .Property(rt => rt.RoomTypeId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<User>()
        .Property(u => u.UserId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();

    modelBuilder.Entity<UserRole>()
        .Property(ur => ur.UserRoleId)
        .HasDefaultValueSql("NEWID()")
        .ValueGeneratedOnAdd();
    }
    
    
}