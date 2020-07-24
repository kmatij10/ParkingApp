using System;
using System.Collections.Generic;

namespace ParkingApp.Model
{
    public class Payment: AppModel
    {
        public DateTime IssuedAt{get;set;}
        public decimal Amount{get;set;}
        public string Status{get;set;}
        public PaymentPanel PaymentPanels;

        public Payment(DateTime IssuedAt, decimal Amount, string Status, PaymentPanel PaymentPanels){
            this.IssuedAt = IssuedAt;
            this.Amount = Amount;
            this.Status = Status;
            this.PaymentPanels = PaymentPanels;
        }
    }
}