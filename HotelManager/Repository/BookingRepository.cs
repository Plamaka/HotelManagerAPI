using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManager.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelManagerDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingRepository(HotelManagerDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Booking> GetAll()
        {      
            return _context.Bookings.Include(b => b.BookingRooms).ThenInclude(br => br.Room).ThenInclude(r => r.RoomStatus).ToList();
        }        

        public List<Booking> GetBookingsByGuest(string id)
        {
            return _context.Bookings
         .Include(b => b.BookingRooms)
             .ThenInclude(br => br.Room)
         .Include(b => b.BookingGuests)
         .Include(b => b.PaymentStatus)
         .Where(b => b.BookingGuests.Any(g => g.GuestId == id))
         .ToList();
        }

        public Booking GetById(int id)
        {
            return _context.Bookings.Include(b => b.BookingRooms)
                .ThenInclude(br => br.Room)
                .ThenInclude(r => r.RoomClass)
                .Include(b => b.BookingGuests)
                .Include(b => b.PaymentStatus)
                .FirstOrDefault(b => b.Id == id);
        }

        public bool Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            return Save();
        }

        public bool Delete(Booking booking)
        {
            _context.Bookings.Remove(booking);
            return Save();
        }       

        public bool Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool AddBookingGuest(BookingGuest guest)
        {
           _context.BookingGuests.Add(guest);
            return Save();
        }

        public List<Booking> GetBookingsInDateRange(DateTime checkInDate, DateTime checkOutDate)
        {
            return _context.Bookings
                .Include(b => b.BookingRooms)
                .Where(b => b.CheckInDate < checkOutDate && b.CheckOutDate > checkInDate)
                .ToList();
        }
    }
}
