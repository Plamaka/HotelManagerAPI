namespace HotelManager.DTOs
{
    public class CreateBookingDTO
    {
        public int GuestId { get; set; }

        public List<int> RoomIds { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int NumOfAdult { get; set; }

        public int NumOfChild { get; set; }

        public bool pet { get; set; }

        public int PaymentStatusId { get; set; }
    }
        
}
