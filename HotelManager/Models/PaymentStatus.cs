using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class PaymentStatus
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(30)")]
        public required string StatusName { get; set; }

        public ICollection<Booking> Bookings { get; set; } 
    }
}