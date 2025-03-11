using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;
using System.Linq;

namespace HotelManager.Repository
{
    public class RoomStatusRepository : IRoomStatusRepository
    {
        private readonly HotelManagerDbContext _context;

        public RoomStatusRepository(HotelManagerDbContext context)
        {
            _context = context;
        }
        public List<RoomStatus> GetAll()
        {
            return _context.RoomStatuses.ToList();
        }

        public RoomStatus GetByName(string name)
        {
            return _context.RoomStatuses.FirstOrDefault(rs =>rs.StatusName == name);
        }

        public RoomStatus GetById(int Id)
        {
            return _context.RoomStatuses.FirstOrDefault(rs => rs.Id == Id);
        }

        public bool Add(RoomStatus roomStatus)
        {
            _context.Add(roomStatus);
            return Save();
        }

        public bool Delete(RoomStatus roomStatus)
        {
            _context.Remove(roomStatus);
            return Save();
        }

        public bool Update(RoomStatus roomStatus)
        {
            _context.Update(roomStatus);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
