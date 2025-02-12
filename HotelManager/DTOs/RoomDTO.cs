using HotelManager.Models;

namespace HotelManager.DTOs
{
    public class RoomDTO
    {
        public required string Description { get; set; }

        public int RoomClassId { get; set; }

        public int RoomStatusId { get; set; }

        public required int RoomFloor { get; set; }

        public required int RoomNumber { get; set; }
    }
}
