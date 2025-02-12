using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface IPaymentStatusRepository
    {
        List<PaymentStatus> GetAll();

        PaymentStatus GetById(int Id);

        bool Add(PaymentStatus paymentStatus);

        bool Update(PaymentStatus paymentStatus);

        bool Delete(PaymentStatus paymentStatus);

        bool Save();
    }
}
