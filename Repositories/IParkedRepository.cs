using System.Collections.Generic;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public interface IParkedRepository
    {
        public Parked GetOne(long id);
        public IEnumerable<Parked> GetAll();
        public IEnumerable<Parked> GetParked(IEnumerable<long> ids);
        public Parked CreateParked(Parked parked);
        public bool DeleteParked(long id);
        public Parked UpdateParked(long id, Parked newParked);
    }
}