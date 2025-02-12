using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class RoomStatus
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(30)")]
        public required string StatusName { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}