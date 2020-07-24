namespace ParkingApp.Model
{
    public class Rate: AppModel
    {
        public decimal PriceHourly{get;set;}

        public Rate(decimal PriceHourly){
            this.PriceHourly = PriceHourly;
        }
    }
}