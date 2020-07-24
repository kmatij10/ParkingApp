using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly ParkingContext context;

        public DriverRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Driver> GetAll()
        {
            return this.context.Drivers.ToList();
        }

        public Driver GetOne(long id)
        {
            return this.context.Drivers.Where(c => c.Id == id).Single();
        }
        public IEnumerable<Driver> GetDriver(IEnumerable<long> ids)
        {
            return this.context.Drivers.Where(c => ids.Contains(c.Id)).ToList();
        }

        public Driver CreateDriver(Driver c)
        {
            this.context.Drivers.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool DeleteDriver(long id)
        {
            this.context.Drivers.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Driver UpdateDriver(long id, Driver newDriver)
        {
            newDriver.Id = id;
            this.context.Entry(newDriver).State = EntityState.Modified;
            this.context.SaveChanges();

            return newDriver;
        }
    }
}