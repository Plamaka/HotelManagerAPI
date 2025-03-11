using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface IRoomRepository
    {
        List<Room> GetAll();

        List<Room> SearchFreeRoom();

        List<Room> SearchFreeRoomAllowsPet();

        Room GetById(int Id);

        bool Add(Room room);

        bool Update(Room room);

        bool Delete(Room room);

        bool Save();
    }
}
