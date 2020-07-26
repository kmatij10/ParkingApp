using System;

namespace ParkingApp.Model.DTO
{
    public class PaymentPanelDetailDTO
    {
        public long Id { get; set; }
        public int PayedForHours{get;set;}
        public DateTime ChargingStart{get;set;}
        public long ParkedId { get; set; }
    }
}