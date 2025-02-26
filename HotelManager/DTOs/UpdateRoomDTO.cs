using HotelManager.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.DTOs
{
    public class UpdateRoomDTO
    {
        public required string Description { get; set; }

        public int RoomClassId { get; set; }

        public int RoomStatusId { get; set; }

        public required int RoomFloor { get; set; }

        public required int RoomNumber { get; set; }
    }
}
