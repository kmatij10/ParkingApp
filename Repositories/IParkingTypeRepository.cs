using System.Collections.Generic;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public interface IParkingTypeRepository
    {
        public ParkingType GetOne(long id);
        public IEnumerable<ParkingType> GetAll();
        public IEnumerable<ParkingType> GetParkingType(IEnumerable<long> ids);
        public ParkingType CreateParkingType(ParkingType parkingType);
        public bool DeleteParkingType(long id);
        public ParkingType UpdateParkingType(long id, ParkingType newParkingType);
    }
}