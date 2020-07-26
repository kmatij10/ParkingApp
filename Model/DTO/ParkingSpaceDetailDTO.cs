namespace ParkingApp.Model.DTO
{
    public class ParkingSpaceDetailDTO
    {
        public long Id { get; set; }
        public double Lat{get;set;}
        public double Lng{get;set;}
        public long ParkingTypeId { get; set; }
        public long RateId { get; set; }
    }
}