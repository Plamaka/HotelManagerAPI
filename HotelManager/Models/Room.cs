using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(500)")]
        public required string Description { get; set; }

        public int RoomClassId { get; set; }
        public RoomClass RoomClass { get; set; }

        public int RoomStatusId { get; set; }
        public RoomStatus RoomStatus { get; set; }

        public required int RoomFloor { get; set; }

        public required int RoomNumber { get; set; }

        public ICollection<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();
    }
}
