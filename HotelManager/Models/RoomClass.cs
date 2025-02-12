using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class RoomClass
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(30)")]
        public required string ClassName { get; set; }

        public required byte Capacity { get; set; }

        public bool AllowsPet { get; set; }

        [Column(TypeName = "DECIMAL(8,2)")]
        public required decimal BasePrice { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        public ICollection<RoomClassFeature> RoomClassFeatures { get; set; } = new List<RoomClassFeature>();
    }
}