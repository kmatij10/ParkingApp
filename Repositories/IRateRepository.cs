using System.Collections.Generic;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public interface IRateRepository
    {
        public Rate GetOne(long id);
        public IEnumerable<Rate> GetAll();
        public IEnumerable<Rate> GetRate(IEnumerable<long> ids);
        public Rate CreateRate(Rate rate);
        public bool DeleteRate(long id);
        public Rate UpdateRate(long id, Rate newRate);
    }
}