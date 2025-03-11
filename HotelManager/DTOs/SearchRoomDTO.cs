namespace HotelManager.DTOs
{
    public class SearchRoomDTO
    {
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int NumOfAdult { get; set; }

        public int NumOfChild { get; set; }

        public bool pet { get; set; }
    }
}

