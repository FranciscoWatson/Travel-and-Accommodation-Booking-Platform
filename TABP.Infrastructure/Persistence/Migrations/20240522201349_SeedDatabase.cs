using Microsoft.EntityFrameworkCore.Migrations;
using TABP.Domain.Enums;

#nullable disable

namespace TABP.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        private static readonly Guid countryIdArgentina = Guid.NewGuid();
        private static readonly Guid countryIdBrazil = Guid.NewGuid();
        private static readonly Guid countryIdUSA = Guid.NewGuid();

        private static readonly Guid cityIdBuenosAires = Guid.NewGuid();
        private static readonly Guid cityIdRio = Guid.NewGuid();
        private static readonly Guid cityIdNYC = Guid.NewGuid();

        private static readonly Guid ownerId1 = Guid.NewGuid();
        private static readonly Guid ownerId2 = Guid.NewGuid();
        private static readonly Guid ownerId3 = Guid.NewGuid();

        private static readonly Guid hotelId1 = Guid.NewGuid();
        private static readonly Guid hotelId2 = Guid.NewGuid();
        private static readonly Guid hotelId3 = Guid.NewGuid();

        private static readonly Guid amenityId1 = Guid.NewGuid();
        private static readonly Guid amenityId3 = Guid.NewGuid();

        private static readonly Guid roomTypeStandardId = Guid.NewGuid();
        private static readonly Guid roomTypeDeluxeId = Guid.NewGuid();
        private static readonly Guid roomTypeFamilyId = Guid.NewGuid();

        private static readonly Guid roomId101 = Guid.NewGuid();
        private static readonly Guid roomId102 = Guid.NewGuid();
        private static readonly Guid roomId103 = Guid.NewGuid();

        private static readonly Guid userRoleGuest = Guid.NewGuid();
        private static readonly Guid userRoleAdmin = Guid.NewGuid();

        private static readonly Guid userId1 = Guid.NewGuid();
        private static readonly Guid userId2 = Guid.NewGuid();
        private static readonly Guid userId3 = Guid.NewGuid();

        private static readonly Guid bookingId1 = Guid.NewGuid();
        private static readonly Guid bookingId2 = Guid.NewGuid();
        private static readonly Guid bookingId3 = Guid.NewGuid();

        private static readonly Guid paymentId1 = Guid.NewGuid();
        private static readonly Guid paymentId2 = Guid.NewGuid();
        private static readonly Guid paymentId3 = Guid.NewGuid();

        private static readonly Guid reviewId1 = Guid.NewGuid();
        private static readonly Guid reviewId2 = Guid.NewGuid();
        private static readonly Guid reviewId3 = Guid.NewGuid();

        private static readonly Guid hotelImageId1 = Guid.NewGuid();
        private static readonly Guid hotelImageId2 = Guid.NewGuid();
        private static readonly Guid hotelImageId3 = Guid.NewGuid();

        private static readonly Guid roomDiscountId1 = Guid.NewGuid();
        private static readonly Guid roomDiscountId2 = Guid.NewGuid();

        private static readonly Guid roomImageId1 = Guid.NewGuid();
        private static readonly Guid roomImageId2 = Guid.NewGuid();
        private static readonly Guid roomImageId3 = Guid.NewGuid();
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name", "Code", "Description" },
                values: new object[,]
                {
                    { countryIdArgentina, "Argentina", "AR", "Located in South America." },
                    { countryIdBrazil, "Brazil", "BR", "Country in South America known for its large biodiversity." },
                    { countryIdUSA, "United States", "US", "Country located in North America." }
                });
            
            
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Name", "Description", "CountryId" },
                values: new object[,]
                {
                    { cityIdBuenosAires, "Buenos Aires", "Capital of Argentina", countryIdArgentina },
                    { cityIdRio, "Rio de Janeiro", "A beautiful city with famous beaches.", countryIdBrazil },
                    { cityIdNYC, "New York City", "The city that never sleeps.", countryIdUSA }
                });
            
            

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "FirstName", "LastName", "Email", "PhoneNumber" },
                values: new object[,]
                {
                    { ownerId1, "John", "Doe", "john.doe@example.com", "000-000-0000" },
                    { ownerId2, "Maria", "Silva", "maria.silva@example.com", "111-111-1111" },
                    { ownerId3, "James", "Smith", "james.smith@example.com", "222-222-2222" }
                });
            
            
            
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "CityId", "OwnerId", "Name", "Description", "PhoneNumber", "Email", "StarRating", "Address", "Latitude", "Longitude", "CreatedDate"},
                values: new object[,]
                {
                    { hotelId1, cityIdBuenosAires, ownerId1, "Luxe Hotel", "A luxurious hotel in the heart of the city.", "000-000-0000", "info@luxehotel.com", 5, "123 Luxe Street", "-34.6037", "-58.3816", DateTime.Today },
                    { hotelId2, cityIdRio, ownerId2, "Paradise Hotel", "Enjoy your stay at the heart of Rio.", "333-000-0000", "contact@paradise.com", 4.0f, "456 Paradise Ave", "-22.9068", "-43.1729", DateTime.Today},
                    { hotelId3, cityIdNYC, ownerId3, "Metro Hotel", "Best place to explore NYC.", "444-000-0000", "hello@metrohotel.com", 4.5f, "789 Metro St", "40.7128", "-74.0060", DateTime.Today}
                });
            

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "AmenityId", "Name", "Description" },
                values: new object[,]
                {
                    { amenityId1, "Free WiFi", "High-speed internet access available throughout the hotel." },
                    { amenityId3, "Pool", "Outdoor pool available for guests." }
                });
            
            migrationBuilder.InsertData(
                table: "HotelAmenity", // This is the join table's name
                columns: new[] { "HotelId", "AmenityId" },
                values: new object[,]
                {
                    { hotelId1, amenityId1 },
                    { hotelId2, amenityId1 },
                    { hotelId3, amenityId1 },
                    { hotelId1, amenityId3 },
                    { hotelId2, amenityId3 }
                });
            

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId","HotelId","Name", "AdultsCapacity", "ChildrenCapacity" ,"Description", "Price" },
                values: new object[,]
                {
                    { roomTypeStandardId, hotelId1, "Standard", 2, 1, "Standard room with basic amenities.", 150m},
                    { roomTypeDeluxeId, hotelId1,"Deluxe", 2, 1, "A deluxe room with enhanced amenities.", 200m},
                    { roomTypeFamilyId, hotelId2,"Family", 3, 2, "A spacious room suitable for families.", 250m}
                });
            
           
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "RoomTypeId", "RoomNumber", "CreatedDate"},
                values: new object[,]
                {
                    { roomId101, roomTypeStandardId, 101, DateTime.Today},
                    { roomId102, roomTypeFamilyId, 102, DateTime.Today},
                    { roomId103, roomTypeFamilyId, 201, DateTime.Today}
                });
            
            
           
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "Name" },
                values: new object[,]
                {
                    { userRoleGuest, "Guest" },
                    { userRoleAdmin, "Admin" }
                });
            
           
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserRoleId", "UserName", "FirstName", "LastName", "Password", "Email", "PhoneNumber", "CreatedDate" },
                values: new object[,]
                {
                    { userId1, userRoleGuest, "johndoe", "John", "Doe", "hashed-password", "john.doe@example.com", "111-222-3333", DateTime.Today},
                    { userId2, userRoleGuest, "alicejohnson", "Alice", "Johnson", "password2", "alice.johnson@example.com", "333-333-3333", DateTime.Today},
                    { userId3, userRoleAdmin, "bobsmith", "Bob", "Smith", "password3", "bob.smith@example.com", "444-444-4444", DateTime.Today}
                });
            
            
           
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "UserId", "CheckIn", "CheckOut", "PriceAtBooking", "CreatedDate" },
                values: new object[,]
                {
                    { bookingId1, userId1, DateTime.Today, DateTime.Today.AddDays(3), 450m, DateTime.Today},
                    { bookingId2, userId1, DateTime.Today.AddDays(10), DateTime.Today.AddDays(13), 360m, DateTime.Today},
                    { bookingId3, userId2, DateTime.Today.AddDays(15), DateTime.Today.AddDays(18), 540m, DateTime.Today}
                });

            migrationBuilder.InsertData(
                table: "BookingRoom",
                columns: new[] { "BookingId", "RoomId" },
                values: new object[,]
                {
                    { bookingId1, roomId101 },
                    { bookingId2, roomId102 },
                    { bookingId3, roomId103 }
                });
            
            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "BookingId", "Amount", "PaymentMethod", "PaymentStatus", "PaymentDate", "CreatedDate"},
                values: new object[,]
                {
                    { paymentId1, bookingId1, 450m, (int)PaymentMethod.CreditCard, (int)PaymentStatus.Paid, DateTime.Today, DateTime.Today},
                    { paymentId2, bookingId2, 360m, (int)PaymentMethod.CreditCard, (int)PaymentStatus.Paid, DateTime.Today, DateTime.Today},
                    { paymentId3, bookingId3, 540m, (int)PaymentMethod.CreditCard, (int)PaymentStatus.Paid, DateTime.Today, DateTime.Today}
                });
            
            
          
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "HotelId", "UserId", "Content", "Rating", "CreatedDate"},
                values: new object[,]
                {
                    { reviewId1, hotelId1, userId1, "Excellent service and location!", 5.0f, DateTime.Today},
                    { reviewId2, hotelId2, userId2, "Great location and friendly staff.", 4.0f, DateTime.Today},
                    { reviewId3, hotelId3, userId3, "Perfect for a weekend getaway.", 4.5f, DateTime.Today}
                });
            
   
            migrationBuilder.InsertData(
                table: "HotelImages",
                columns: new[] { "HotelImageId", "HotelId", "Url" },
                values: new object[,]
                {
                    { hotelImageId1, hotelId1, "https://example.com/images/hotel1.jpg" },
                    { hotelImageId2, hotelId2, "https://example.com/images/hotel2.jpg" },
                    { hotelImageId3, hotelId3, "https://example.com/images/hotel3.jpg" }
                });
            
            
         
            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "DiscountId", "RoomTypeId", "Percentage", "StartDate", "EndDate", "CreatedDate"},
                values: new object[,]
                {
                    { roomDiscountId1, roomTypeStandardId, 10.0f, DateTime.Today, DateTime.Today.AddDays(30), DateTime.Today},
                    { roomDiscountId2, roomTypeDeluxeId, 15.0f, DateTime.Today, DateTime.Today.AddDays(30), DateTime.Today}
                });
            
          
            migrationBuilder.InsertData(
                table: "RoomImages",
                columns: new[] { "RoomImageId", "RoomTypeId","Url" },
                values: new object[,]
                {
                    { roomImageId1, roomTypeDeluxeId ,"https://example.com/images/room101.jpg" },
                    { roomImageId2, roomTypeDeluxeId, "https://example.com/images/room102.jpg" },
                    { roomImageId3, roomTypeDeluxeId, "https://example.com/images/room201.jpg" }
                });
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
        table: "RoomImages",
        keyColumn: "RoomImageId",
        keyValues: new object[] { roomImageId1, roomImageId2, roomImageId3 });

    // Remove data from Discounts table
    migrationBuilder.DeleteData(
        table: "Discounts",
        keyColumn: "DiscountId",
        keyValues: new object[] { roomDiscountId1, roomDiscountId2 });

    // Remove data from HotelImages table
    migrationBuilder.DeleteData(
        table: "HotelImages",
        keyColumn: "HotelImageId",
        keyValues: new object[] { hotelImageId1, hotelImageId2, hotelImageId3 });

    // Remove data from Reviews table
    migrationBuilder.DeleteData(
        table: "Reviews",
        keyColumn: "ReviewId",
        keyValues: new object[] { reviewId1, reviewId2, reviewId3 });

    // Remove data from Payments table
    migrationBuilder.DeleteData(
        table: "Payments",
        keyColumn: "PaymentId",
        keyValues: new object[] { paymentId1, paymentId2, paymentId3 });

    // Remove data from BookingsRooms table
    migrationBuilder.DeleteData(
        table: "BookingRoom",
        keyColumns: new[] { "BookingId", "RoomId" },
        keyValues: new object[] { bookingId1, roomId101 });
    migrationBuilder.DeleteData(
        table: "BookingRoom",
        keyColumns: new[] { "BookingId", "RoomId" },
        keyValues: new object[] { bookingId2, roomId102 });
    migrationBuilder.DeleteData(
        table: "BookingRoom",
        keyColumns: new[] { "BookingId", "RoomId" },
        keyValues: new object[] { bookingId3, roomId103 });

    // Remove data from Bookings table
    migrationBuilder.DeleteData(
        table: "Bookings",
        keyColumn: "BookingId",
        keyValues: new object[] { bookingId1, bookingId2, bookingId3 });

    // Remove data from Users table
    migrationBuilder.DeleteData(
        table: "Users",
        keyColumn: "UserId",
        keyValues: new object[] { userId1, userId2, userId3 });

    // Remove data from UserRoles table
    migrationBuilder.DeleteData(
        table: "UserRoles",
        keyColumn: "UserRoleId",
        keyValues: new object[] { userRoleGuest, userRoleAdmin });

    // Remove data from Rooms table
    migrationBuilder.DeleteData(
        table: "Rooms",
        keyColumn: "RoomId",
        keyValues: new object[] { roomId101, roomId102, roomId103 });

    // Remove data from RoomTypes table
    migrationBuilder.DeleteData(
        table: "RoomTypes",
        keyColumn: "RoomTypeId",
        keyValues: new object[] { roomTypeStandardId, roomTypeDeluxeId, roomTypeFamilyId });

    // Remove data from HotelAmenity table
    migrationBuilder.DeleteData(
        table: "HotelAmenity",
        keyColumns: new[] { "HotelId", "AmenityId" },
        keyValues: new object[] { hotelId1, amenityId1 });
    migrationBuilder.DeleteData(
        table: "HotelAmenity",
        keyColumns: new[] { "HotelId", "AmenityId" },
        keyValues: new object[] { hotelId2, amenityId1 });
    migrationBuilder.DeleteData(
        table: "HotelAmenity",
        keyColumns: new[] { "HotelId", "AmenityId" },
        keyValues: new object[] { hotelId3, amenityId1 });
    migrationBuilder.DeleteData(
        table: "HotelAmenity",
        keyColumns: new[] { "HotelId", "AmenityId" },
        keyValues: new object[] { hotelId1, amenityId3 });
    migrationBuilder.DeleteData(
        table: "HotelAmenity",
        keyColumns: new[] { "HotelId", "AmenityId" },
        keyValues: new object[] { hotelId2, amenityId3 });

    // Remove data from Amenities table
    migrationBuilder.DeleteData(
        table: "Amenities",
        keyColumn: "AmenityId",
        keyValues: new object[] { amenityId1, amenityId3 });

    // Remove data from Hotels table
    migrationBuilder.DeleteData(
        table: "Hotels",
        keyColumn: "HotelId",
        keyValues: new object[] { hotelId1, hotelId2, hotelId3 });

    // Remove data from Owners table
    migrationBuilder.DeleteData(
        table: "Owners",
        keyColumn: "OwnerId",
        keyValues: new object[] { ownerId1, ownerId2, ownerId3 });

    // Remove data from Cities table
    migrationBuilder.DeleteData(
        table: "Cities",
        keyColumn: "CityId",
        keyValues: new object[] { cityIdBuenosAires, cityIdRio, cityIdNYC });

    // Remove data from Countries table
    migrationBuilder.DeleteData(
        table: "Countries",
        keyColumn: "CountryId",
        keyValues: new object[] { countryIdArgentina, countryIdBrazil, countryIdUSA });
        }
    }
}
