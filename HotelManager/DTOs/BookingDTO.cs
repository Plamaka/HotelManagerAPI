using HotelManager.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }

        public Guest Guest { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int NumOfAdult { get; set; }

        public int NumOfChild { get; set; }

        public int Room { get; set; }

        public bool pet { get; set; }

        public decimal BookingAmount { get; set; }
    }
}
