using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkingApp.Model
{
    public class Payment: AppModel
    {
        [Required]
        public DateTime IssuedAt{get;set;}
        [Required]
        public decimal Amount{get;set;}
        [Required]
        public string Status{get;set;}

        public long PaymentPanelId { get; set; }
        //public PaymentPanel PaymentPanels;

        /*public Payment(DateTime IssuedAt, decimal Amount, string Status, PaymentPanel PaymentPanels){
            this.IssuedAt = IssuedAt;
            this.Amount = Amount;
            this.Status = Status;
            this.PaymentPanels = PaymentPanels;
        }*/
    }
}