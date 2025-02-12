using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface IRoomStatusRepository
    {
        List<RoomStatus> GetAll();

        RoomStatus GetById(int Id);

        bool Add(RoomStatus roomStatus);

        bool Update(RoomStatus roomStatus);

        bool Delete(RoomStatus roomStatus);

        bool Save();
    }
}
