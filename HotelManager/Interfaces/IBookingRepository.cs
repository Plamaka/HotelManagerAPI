using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface IBookingRepository
    {
        List<Booking> GetAll();

        Booking GetById(int Id);

        bool Add(Booking booking);

        bool Update(Booking booking);

        bool Delete(Booking booking);

        bool Save();
    }
}
