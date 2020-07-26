using System;

namespace ParkingApp.Model.DTO
{
    public class ParkedCreateDTO
    {
        public DateTime From{get;set;}
        public DateTime To{get;set;}

        public long DriverId { get; set; }
        public long RequestStatusId { get; set; }
        public long ParkingSpaceId { get; set; }
    }
}