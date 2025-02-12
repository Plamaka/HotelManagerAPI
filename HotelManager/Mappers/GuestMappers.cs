using HotelManager.DTOs;
using HotelManager.Models;

namespace HotelManager.Mappers
{
    public static class GuestMappers
    {
        public static GuestDTO ToGuestDTO(this Guest guestModel)
        {
            return new GuestDTO
            {
                FirstName = guestModel.FirstName,
                LastName = guestModel.LastName,
                Email = guestModel.Email
            };
        }
    }
}
