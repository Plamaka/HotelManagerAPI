﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.DTOs
{
    public class GuestDTO
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }
    }
}
