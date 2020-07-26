using System;

namespace ParkingApp.Model.DTO
{
    public class PaymentDetailDTO
    {
        public long Id { get; set; }
        public DateTime IssuedAt{get;set;}
    
        public decimal Amount{get;set;}

        public string Status{get;set;}

        public long PaymentPanelId { get; set; }
    }
}