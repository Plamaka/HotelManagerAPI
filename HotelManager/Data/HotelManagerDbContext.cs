using HotelManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManager.Data
{
    public class HotelManagerDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingRoom> BookingRooms { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomClass> RoomClasses { get; set; }

        public DbSet<RoomClassFeature> RoomClassFeatures { get; set; }

        public DbSet<RoomStatus> RoomStatuses { get; set; }

        public HotelManagerDbContext(DbContextOptions<HotelManagerDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingRoom>().HasKey(br => new {br.BookingId, br.RoomId});
            modelBuilder.Entity<RoomClassFeature>().HasKey(rf => new {rf.FeatureId, rf.RoomClassId});
        }
    }
}
