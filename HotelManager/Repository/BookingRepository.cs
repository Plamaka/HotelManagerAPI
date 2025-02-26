using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManager.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelManagerDbContext _context;

        public BookingRepository(HotelManagerDbContext context)
        {
            _context = context;
        }

        public List<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetById(int id)
        {
            return _context.Bookings.Include(b => b.BookingRooms)
                .ThenInclude(br => br.Room)
                .ThenInclude(r => r.RoomClass)
                .Include(b => b.Guest)
                .Include(b => b.PaymentStatus)
                .FirstOrDefault(b => b.Id == id);
        }

        public bool Add(Booking booking)
        {
            _context.Add(booking);
            return Save();
        }

        public bool Delete(Booking booking)
        {
            _context.Remove(booking);
            return Save();
        }       

        public bool Update(Booking booking)
        {
            _context.Update(booking);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
