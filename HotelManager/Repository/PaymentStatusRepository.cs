using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;

namespace HotelManager.Repository
{
    public class PaymentStatusRepository : IPaymentStatusRepository
    {
        private readonly HotelManagerDbContext _context;

        public PaymentStatusRepository(HotelManagerDbContext context)
        {
            _context = context;
        }

        public List<PaymentStatus> GetAll()
        {
            return _context.PaymentStatuses.ToList();
        }

        public PaymentStatus GetById(int Id)
        {
            return _context.PaymentStatuses.FirstOrDefault(g => g.Id == Id);
        }

        public bool Add(PaymentStatus paymentStatus)
        {
            _context.Add(paymentStatus);
            return Save();
        }

        public bool Delete(PaymentStatus paymentStatus)
        {
            _context.Remove(paymentStatus);
            return Save();
        }

        public bool Update(PaymentStatus paymentStatus)
        {
            _context.Update(paymentStatus);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
