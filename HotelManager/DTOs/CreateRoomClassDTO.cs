using HotelManager.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.DTOs
{
    public class CreateRoomClassDTO
    {
        public required string ClassName { get; set; }

        public required string Description { get; set; }

        public required byte Capacity { get; set; }

        public required bool AllowsPet { get; set; }

        public required decimal BasePrice { get; set; }

        public required List<int> FeaturesId { get; set; }
    }
}
