using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;

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

        public Booking GetById(int Id)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == Id);
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
