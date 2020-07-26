using System.Collections.Generic;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public interface IParkingSpaceRepository
    {
        public ParkingSpace GetOne(long id);
        public IEnumerable<ParkingSpace> GetAll();
        public IEnumerable<ParkingSpace> GetParkingSpace(IEnumerable<long> ids);
        public ParkingSpace CreateParkingSpace(ParkingSpace parkingSpace);
        public bool DeleteParkingSpace(long id);
        public ParkingSpace UpdateParkingSpace(long id, ParkingSpace newParkingSpace);
    }
}