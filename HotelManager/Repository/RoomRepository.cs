using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;

namespace HotelManager.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelManagerDbContext _context;

        public RoomRepository(HotelManagerDbContext context)
        {
            _context = context;
        }

        public List<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(int Id)
        {
            return _context.Rooms.FirstOrDefault(r => r.Id == Id);
        }

        public bool Add(Room room)
        {
            _context.Add(room);
            return Save();
        }

        public bool Delete(Room room)
        {
            _context.Remove(room);
            return Save();
        }

        public bool Update(Room room)
        {
            _context.Update(room);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
