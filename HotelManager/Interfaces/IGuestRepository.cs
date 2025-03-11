using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface IGuestRepository
    {
        List<Guest> GetAll();

        Guest GetById(string Id);

        bool Add(Guest guest);

        bool Update(Guest guest);

        bool Delete(Guest guest);

        bool Save();
    }
}
