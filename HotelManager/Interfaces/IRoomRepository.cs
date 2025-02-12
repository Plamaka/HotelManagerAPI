using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface IRoomRepository
    {
        List<Room> GetAll();

        Room GetById(int Id);

        bool Add(Room room);

        bool Update(Room room);

        bool Delete(Room room);

        bool Save();
    }
}
