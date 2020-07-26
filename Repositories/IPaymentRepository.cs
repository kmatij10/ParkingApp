using System.Collections.Generic;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public interface IPaymentRepository
    {
        public Payment GetOne(long id);
        public IEnumerable<Payment> GetAll();
        public IEnumerable<Payment> GetPayment(IEnumerable<long> ids);
        public Payment CreatePayment(Payment payment);
        public bool DeletePayment(long id);
        public Payment UpdatePayment(long id, Payment newPayment);
    }
}