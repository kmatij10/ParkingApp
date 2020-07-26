namespace ParkingApp.Model.DTO
{
    public class ParkingSpaceCreateDTO
    {
        public double Lat{get;set;}
        public double Lng{get;set;}
        public long ParkingTypeId { get; set; }
        public long RateId { get; set; }
    }
}