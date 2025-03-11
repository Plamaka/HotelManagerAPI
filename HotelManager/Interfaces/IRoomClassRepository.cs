using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface IRoomClassRepository
    {
        List<RoomClass> GetAll();

        RoomClass GetById(int Id);

        List<RoomClass> SearchByPrice(decimal priceMin, decimal priceMax);

        bool RoomClassExists(int id);

        bool Add(RoomClass roomClass);

        bool Update(RoomClass roomClass);

        bool Delete(RoomClass roomClass);

        bool Save();
    }
}
