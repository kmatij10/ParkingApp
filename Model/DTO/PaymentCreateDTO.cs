using System;

namespace ParkingApp.Model.DTO
{
    public class PaymentCreateDTO
    {
        public DateTime IssuedAt{get;set;}
    
        public decimal Amount{get;set;}

        public string Status{get;set;}

        public long PaymentPanelId { get; set; }
    }
}