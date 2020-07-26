using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public class PaymentPanelRepository : IPaymentPanelRepository
    {
        private readonly ParkingContext context;

        public PaymentPanelRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<PaymentPanel> GetAll()
        {
            return this.context.PaymentPanels.ToList();
        }
        public PaymentPanel GetOne(long id)
        {
            return this.context.PaymentPanels.Where(c => c.Id == id).Single();
        }

        public IEnumerable<PaymentPanel> GetPaymentPanel(IEnumerable<long> ids)
        {
            return this.context.PaymentPanels.Where(c => ids.Contains(c.Id)).ToList();
        }
        public PaymentPanel CreatePaymentPanel(PaymentPanel c)
        {
            this.context.PaymentPanels.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool DeletePaymentPanel(long id)
        {
            this.context.PaymentPanels.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public PaymentPanel UpdatePaymentPanel(long id, PaymentPanel newPaymentPanel)
        {
            newPaymentPanel.Id = id;
            this.context.Entry(newPaymentPanel).State = EntityState.Modified;
            this.context.SaveChanges();

            return newPaymentPanel;
        }
    }
}