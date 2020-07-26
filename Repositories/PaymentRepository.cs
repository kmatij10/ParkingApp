using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ParkingContext context;

        public PaymentRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Payment> GetAll()
        {
            return this.context.Payments.ToList();
        }
        public Payment GetOne(long id)
        {
            return this.context.Payments.Where(c => c.Id == id).Single();
        }

        public IEnumerable<Payment> GetPayment(IEnumerable<long> ids)
        {
            return this.context.Payments.Where(c => ids.Contains(c.Id)).ToList();
        }
        public Payment CreatePayment(Payment c)
        {
            this.context.Payments.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool DeletePayment(long id)
        {
            this.context.Payments.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Payment UpdatePayment(long id, Payment newPayment)
        {
            newPayment.Id = id;
            this.context.Entry(newPayment).State = EntityState.Modified;
            this.context.SaveChanges();

            return newPayment;
        }
    }
}