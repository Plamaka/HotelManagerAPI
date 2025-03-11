using HotelManager.Models;

namespace HotelManager.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }       

        public int RoomClassId { get; set; }

        public int RoomStatusId { get; set; }

        public required int RoomFloor { get; set; }

        public required int RoomNumber { get; set; }
    }
}
