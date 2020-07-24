using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ParkingContext context;

        public CarRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Car> GetAll()
        {
            return this.context.Cars.ToList();
        }

        public Car GetOne(long id)
        {
            return this.context.Cars.Where(c => c.Id == id).Single();
        }

        public IEnumerable<Car> GetCar(IEnumerable<long> ids)
        {
            return this.context.Cars.Where(c => ids.Contains(c.Id)).ToList();
        }

        public Car CreateCar(Car c)
        {
            this.context.Cars.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool DeleteCar(long id)
        {
            this.context.Cars.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }

        public Car UpdateCar(long id, Car newCar)
        {
            newCar.Id = id;
            this.context.Entry(newCar).State = EntityState.Modified;
            this.context.SaveChanges();

            return newCar;
        }
    }
}