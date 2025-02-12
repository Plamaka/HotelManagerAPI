using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;

namespace HotelManager.Repository
{
    public class RoomClassRepository : IRoomClassRepository
    {
        private readonly HotelManagerDbContext _context;

        public RoomClassRepository(HotelManagerDbContext context)
        {
            _context = context;
        }

        public List<RoomClass> GetAll()
        {
            return _context.RoomClasses.ToList();
        }

        public RoomClass GetById(int Id)
        {
            return _context.RoomClasses.FirstOrDefault(rc => rc.Id == Id);
        }

        public bool Add(RoomClass roomClass)
        {
            _context.Add(roomClass);
            return Save();
        }

        public bool Delete(RoomClass roomClass)
        {
            _context.Remove(roomClass);
            return Save();
        }

        public bool Update(RoomClass roomClass)
        {
            _context.Update(roomClass);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
