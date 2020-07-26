using System;
using System.Collections.Generic;

namespace ParkingApp.Model
{
    public class PaymentPanel: AppModel
    {
        public int PayedForHours{get;set;}
        public DateTime ChargingStart{get;set;}
        public long ParkedId { get; set; }
        //public Parked Parked;

        /*public PaymentPanel(int PayedForHours, DateTime ChargingStart, Parked Parked){
            this.PayedForHours = PayedForHours;
            this.ChargingStart = ChargingStart;
            this.Parked = Parked;
        }*/
    }
}