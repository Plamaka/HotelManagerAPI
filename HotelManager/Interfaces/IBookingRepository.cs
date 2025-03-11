using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface IBookingRepository
    {
        List<Booking> GetAll();

        List<Booking> GetBookingsByGuest(string id);

        Booking GetById(int Id);

        List<Booking> GetBookingsInDateRange(DateTime checkInDate, DateTime checkOutDate);

        bool Add(Booking booking);

        bool AddBookingGuest(BookingGuest guest);

        bool Update(Booking booking);

        bool Delete(Booking booking);

        bool Save();
    }
}
