using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class Feature
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(30)")]
        public required string FeatureName { get; set; }

        public ICollection<RoomClassFeature> RoomClassFeatures { get; set; } = new List<RoomClassFeature>();
    }
}
