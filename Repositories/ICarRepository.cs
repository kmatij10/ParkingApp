using System.Collections.Generic;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public interface ICarRepository
    {
        public Car GetOne(long id);
        public IEnumerable<Car> GetAll();
        public IEnumerable<Car> GetCar(IEnumerable<long> ids);
        public Car CreateCar(Car car);
        public bool DeleteCar(long id);
        public Car UpdateCar(long id, Car newCar);
    }
}