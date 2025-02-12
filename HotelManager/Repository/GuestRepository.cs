using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;

namespace HotelManager.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelManagerDbContext _context;

        public GuestRepository(HotelManagerDbContext context)
        {
            _context = context;
        }

        public List<Guest> GetAll()
        {
            return _context.Guests.ToList();
        }

        public Guest GetById(int Id)
        {
            return _context.Guests.FirstOrDefault(g => g.Id == Id);
        }

        public bool Add(Guest guest)
        {
            _context.Add(guest);
            return Save();
        }

        public bool Delete(Guest guest)
        {
            _context.Remove(guest);
            return Save();
        }

        public bool Update(Guest guest)
        {
            _context.Update(guest);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
