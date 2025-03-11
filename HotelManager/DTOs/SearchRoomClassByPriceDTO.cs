using HotelManager.Models;

namespace HotelManager.DTOs
{
    public class SearchRoomClassByPriceDTO
    {
        public decimal PriceMin { get; set; }

        public decimal PriceMax { get; set; }
    }
}
