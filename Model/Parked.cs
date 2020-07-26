using System;
using System.Collections.Generic;

namespace ParkingApp.Model
{
    public class Parked: AppModel
    {
        public DateTime From{get;set;}
        public DateTime To{get;set;}

        public long DriverId { get; set; }
        public long RequestStatusId { get; set; }
        public long ParkingSpaceId { get; set; }
        //public Driver Drivers;
        //public RequestStatus RequestStatuses;
        //public ParkingSpace ParkingSpaces;

        /*public Parked(DateTime From, DateTime To, Driver Drivers, RequestStatus RequestStatuses, ParkingSpace ParkingSpaces){
            this.From = From;
            this.To = To;
            this.Drivers = Drivers;
            this.RequestStatuses = RequestStatuses;
            this.ParkingSpaces = ParkingSpaces;
        }*/
    }
}