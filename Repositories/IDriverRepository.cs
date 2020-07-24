using System.Collections.Generic;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public interface IDriverRepository
    {
         public Driver GetOne(long id);
        public IEnumerable<Driver> GetAll();
        public IEnumerable<Driver> GetDriver(IEnumerable<long> ids);

        public Driver CreateDriver(Driver driver);
        public bool DeleteDriver(long id);

        public Driver UpdateDriver(long id, Driver newDriver);
    }
}