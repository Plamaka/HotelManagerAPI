using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Rooms.Include(r => r.RoomClass).ToList();
        }

        public List<Room> SearchFreeRoom()
        {
            return _context.Rooms.Include(r => r.RoomClass).Include(rs => rs.RoomStatus).Where(r => r.RoomStatus.StatusName == "Free").ToList();
        }

        public List<Room> SearchFreeRoomAllowsPet()
        {
            return _context.Rooms.Include(r => r.RoomClass).Include(rs => rs.RoomStatus).Where(rs => rs.RoomClass.AllowsPet == true && rs.RoomStatus.StatusName == "Free").ToList();
        }

 
        public Room GetById(int Id)
        {
            return _context.Rooms.Include(r => r.RoomClass)
                    .ThenInclude(rc => rc.RoomClassFeatures)
                    .ThenInclude(rcf => rcf.Feature)
                    .Include(r => r.RoomStatus).FirstOrDefault(r => r.Id == Id);
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
