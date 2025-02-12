using HotelManager.DTOs;
using HotelManager.Models;

namespace HotelManager.Mappers
{
    public static class PaymentStatusMappers
    {
        public static PaymentStatusDTO CreatePaymentStatusDTO(this PaymentStatus payment)
        {
            return new PaymentStatusDTO
            {
                StatusName = payment.StatusName
            };
        }

        public static PaymentStatus ToPaymentStatusFromDTO(this PaymentStatusDTO statusDTO)
        {
            return new PaymentStatus
            {
                StatusName = statusDTO.StatusName
            };
        }
    }
}
