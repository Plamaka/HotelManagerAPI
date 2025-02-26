using HotelManager.DTOs;
using HotelManager.Models;

namespace HotelManager.Mappers
{
    public static class BookingMappers
    {
        public static BookingDTO ToBookingDTO(this Booking booking)
        {
            return new BookingDTO 
            {
                Id = booking.Id,
                Guest = booking.Guest,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                NumOfAdult = booking.NumOfAdult,
                NumOfChild = booking.NumOfChild,
                pet = booking.pet,
                Room = booking.Room,
                BookingAmount = booking.BookingAmount,
                PaymentStatus = booking.PaymentStatus
            };
        }

        public static Booking ToBookingFromDTO(this CreateBookingDTO createBookingDTO)
        {
            return new Booking
            {
                GuestId = createBookingDTO.GuestId,
                Room = createBookingDTO.RoomIds.Count(),
                BookingRooms = createBookingDTO.RoomIds.Select(id => new BookingRoom { RoomId = id }).ToList(),
                CheckInDate = createBookingDTO.CheckInDate,
                CheckOutDate = createBookingDTO.CheckOutDate,
                NumOfAdult = createBookingDTO.NumOfAdult,
                NumOfChild = createBookingDTO.NumOfChild,
                pet = createBookingDTO.pet,
                PaymentStatusId = createBookingDTO.PaymentStatusId
            };
        }
    }
}
