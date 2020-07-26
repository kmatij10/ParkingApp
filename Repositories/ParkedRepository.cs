using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public class ParkedRepository : IParkedRepository
    {
        private readonly ParkingContext context;

        public ParkedRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Parked> GetAll()
        {
            return this.context.Parked.ToList();
        }
        public Parked GetOne(long id)
        {
            return this.context.Parked.Where(c => c.Id == id).Single();
        }

        public IEnumerable<Parked> GetParked(IEnumerable<long> ids)
        {
            return this.context.Parked.Where(c => ids.Contains(c.Id)).ToList();
        }
        public Parked CreateParked(Parked c)
        {
            this.context.Parked.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool DeleteParked(long id)
        {
            this.context.Parked.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Parked UpdateParked(long id, Parked newParked)
        {
            newParked.Id = id;
            this.context.Entry(newParked).State = EntityState.Modified;
            this.context.SaveChanges();

            return newParked;
        }
    }
}