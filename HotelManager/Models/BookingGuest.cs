namespace HotelManager.Models
{
    public class BookingGuest
    {
        public int BookingId { get; set; }

        public Booking Booking { get; set; }

        public string GuestId { get; set; }

        public Guest Guest { get; set; }
    }
}
