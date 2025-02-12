using HotelManager.DTOs;
using HotelManager.Models;

namespace HotelManager.Mappers
{
    public static class GuestMappers
    {
        public static GuestDTO CreateGuestDTO(this Guest guestModel)
        {
            return new GuestDTO
            {
                FirstName = guestModel.FirstName,
                LastName = guestModel.LastName,
                Email = guestModel.Email,
                PhoneNumber = guestModel.PhoneNumber
            };
        }

        public static Guest ToGuestFromGuestDTO(this GuestDTO guestDTO)
        {
            return new Guest
            {
                FirstName = guestDTO.FirstName,
                LastName = guestDTO.LastName,
                Email = guestDTO.Email,
                PhoneNumber = guestDTO.PhoneNumber
            };
        }
    }
}
