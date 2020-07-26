using System;

namespace ParkingApp.Model.DTO
{
    public class PaymentPanelCreateDTO
    {
        public int PayedForHours{get;set;}
        public DateTime ChargingStart{get;set;}
        public long ParkedId { get; set; }
    }
}