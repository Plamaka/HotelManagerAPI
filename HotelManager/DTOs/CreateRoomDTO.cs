namespace HotelManager.DTOs
{
    public class CreateRoomDTO
    {
        public int RoomClassId { get; set; }

        public required int RoomFloor { get; set; }

        public required int RoomNumber { get; set; }
    }
}
