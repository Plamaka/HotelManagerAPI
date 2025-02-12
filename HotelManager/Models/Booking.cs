using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int GuestId { get; set; }
        public Guest Guest {get; set; }

        public int PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }
     
        public int NumOfAdult { get; set; }
   
        public int NumOfChild { get; set; }
       
        public int Room { get; set; }

        public bool pet { get; set; }

        [Column(TypeName = "DECIMAL(8,2)")]
        public decimal BookingAmount { get; set; }

        public ICollection<BookingRoom> BookingRooms { get; set; } = new List<BookingRoom>();
    }
}
