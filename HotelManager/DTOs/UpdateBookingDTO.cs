using HotelManager.Models;

namespace HotelManager.DTOs
{
    public class UpdateBookingDTO
    {
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }
    }
}
