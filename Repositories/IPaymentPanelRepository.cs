using System.Collections.Generic;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public interface IPaymentPanelRepository
    {
        public PaymentPanel GetOne(long id);
        public IEnumerable<PaymentPanel> GetAll();
        public IEnumerable<PaymentPanel> GetPaymentPanel(IEnumerable<long> ids);
        public PaymentPanel CreatePaymentPanel(PaymentPanel paymentPanel);
        public bool DeletePaymentPanel(long id);
        public PaymentPanel UpdatePaymentPanel(long id, PaymentPanel newPaymentPanel);
    }
}