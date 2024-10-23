﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TABP.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(TabpDbContext))]
    [Migration("20240515203257_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AmenityHotel", b =>
                {
                    b.Property<Guid>("AmenitiesAmenityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HotelsHotelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AmenitiesAmenityId", "HotelsHotelId");

                    b.HasIndex("HotelsHotelId");

                    b.ToTable("AmenityHotel");
                });

            modelBuilder.Entity("BookingRoom", b =>
                {
                    b.Property<Guid>("BookingsBookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomsRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingsBookingId", "RoomsRoomId");

                    b.HasIndex("RoomsRoomId");

                    b.ToTable("BookingRoom");
                });

            modelBuilder.Entity("HotelHotelDiscount", b =>
                {
                    b.Property<Guid>("HotelDiscountsHotelDiscountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HotelsHotelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HotelDiscountsHotelDiscountId", "HotelsHotelId");

                    b.HasIndex("HotelsHotelId");

                    b.ToTable("HotelHotelDiscount");
                });

            modelBuilder.Entity("RoomRoomDiscount", b =>
                {
                    b.Property<Guid>("RoomDiscountsRoomDiscountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomsRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomDiscountsRoomDiscountId", "RoomsRoomId");

                    b.HasIndex("RoomsRoomId");

                    b.ToTable("RoomRoomDiscount");
                });

            modelBuilder.Entity("RoomRoomImage", b =>
                {
                    b.Property<Guid>("RoomImagesRoomImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomsRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomImagesRoomImageId", "RoomsRoomId");

                    b.HasIndex("RoomsRoomId");

                    b.ToTable("RoomRoomImage");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Amenity", b =>
                {
                    b.Property<Guid>("AmenityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AmenityId");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PriceAtBooking")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TABP.Domain.Entities.City", b =>
                {
                    b.Property<Guid>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Hotel", b =>
                {
                    b.Property<Guid>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StarRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.HasIndex("CityId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TABP.Domain.Entities.HotelDiscount", b =>
                {
                    b.Property<Guid>("HotelDiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Percentage")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("HotelDiscountId");

                    b.ToTable("HotelDiscounts");
                });

            modelBuilder.Entity("TABP.Domain.Entities.HotelImage", b =>
                {
                    b.Property<Guid>("HotelImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelImageId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelImages");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Owner", b =>
                {
                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReviewId");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdultsCapacity")
                        .HasColumnType("int");

                    b.Property<int>("ChildrenCapacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("TABP.Domain.Entities.RoomDiscount", b =>
                {
                    b.Property<Guid>("RoomDiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Percentage")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoomDiscountId");

                    b.ToTable("RoomDiscounts");
                });

            modelBuilder.Entity("TABP.Domain.Entities.RoomImage", b =>
                {
                    b.Property<Guid>("RoomImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomImageId");

                    b.ToTable("RoomImages");
                });

            modelBuilder.Entity("TABP.Domain.Entities.RoomType", b =>
                {
                    b.Property<Guid>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("RoomPriceMultiplier")
                        .HasColumnType("real");

                    b.HasKey("RoomTypeId");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("TABP.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TABP.Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("AmenityHotel", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Amenity", null)
                        .WithMany()
                        .HasForeignKey("AmenitiesAmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelsHotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingRoom", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingsBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelHotelDiscount", b =>
                {
                    b.HasOne("TABP.Domain.Entities.HotelDiscount", null)
                        .WithMany()
                        .HasForeignKey("HotelDiscountsHotelDiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelsHotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoomRoomDiscount", b =>
                {
                    b.HasOne("TABP.Domain.Entities.RoomDiscount", null)
                        .WithMany()
                        .HasForeignKey("RoomDiscountsRoomDiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoomRoomImage", b =>
                {
                    b.HasOne("TABP.Domain.Entities.RoomImage", null)
                        .WithMany()
                        .HasForeignKey("RoomImagesRoomImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TABP.Domain.Entities.Booking", b =>
                {
                    b.HasOne("TABP.Domain.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TABP.Domain.Entities.City", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Hotel", b =>
                {
                    b.HasOne("TABP.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TABP.Domain.Entities.HotelImage", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Hotel", null)
                        .WithMany("HotelImages")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TABP.Domain.Entities.Payment", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Booking", "Booking")
                        .WithOne("Payment")
                        .HasForeignKey("TABP.Domain.Entities.Payment", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Review", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Hotel", null)
                        .WithMany("Reviews")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.User", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TABP.Domain.Entities.Room", b =>
                {
                    b.HasOne("TABP.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TABP.Domain.Entities.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("TABP.Domain.Entities.User", b =>
                {
                    b.HasOne("TABP.Domain.Entities.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Booking", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("TABP.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("HotelImages");

                    b.Navigation("Reviews");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("TABP.Domain.Entities.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TABP.Domain.Entities.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
