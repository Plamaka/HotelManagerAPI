using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Models
{
    public class Guest : IdentityUser
    {
        [Column(TypeName = "NVARCHAR(50)")]
        public required string FirstName { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public required string LastName { get; set; }

        [Column(TypeName = "NVARCHAR(80)")]
        public required string Email { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public required string PhoneNumber { get; set; }

        public ICollection<BookingGuest> BookingGuests { get; set; } = new List<BookingGuest>();
    }
}
