using System.Collections.Generic;

namespace ParkingApp.Model
{
    public class ParkingSpace: AppModel
    {
        public double Lat{get;set;}
        public double Lng{get;set;}
        public long ParkingTypeId { get; set; }
        public long RateId { get; set; }
        //public ParkingType ParkingTypes;
        //public Rate Rates;

        /*public ParkingSpace(double Lat, double Lng, ParkingType ParkingTypes, Rate Rates){
            this.Lat = Lat;
            this.Lng = Lng;
            this.ParkingTypes = ParkingTypes;
            this.Rates = Rates;
        }*/
    }
}