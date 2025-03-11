using HotelManager.Models;

namespace HotelManager.DTOs
{
    public class RoomClassDTO
    {
        public required int Id { get; set; }

        public required string ClassName { get; set; }

        public required string Description { get; set; }

        public required byte Capacity { get; set; }

        public required bool AllowsPet { get; set; }

        public int TotalRooms { get; set; }

        public required decimal BasePrice { get; set; }

        public required List<FeatureDTO> Features { get; set; }
    }
}
