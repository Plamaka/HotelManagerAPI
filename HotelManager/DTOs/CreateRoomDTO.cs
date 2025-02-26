namespace HotelManager.DTOs
{
    public class CreateRoomDTO
    {
        public required string Description { get; set; }

        public int RoomClassId { get; set; }

        public required int RoomFloor { get; set; }

        public required int RoomNumber { get; set; }
    }
}
