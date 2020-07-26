using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly ParkingContext context;

        public RateRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Rate> GetAll()
        {
            return this.context.Rates.ToList();
        }
        public Rate GetOne(long id)
        {
            return this.context.Rates.Where(c => c.Id == id).Single();
        }

        public IEnumerable<Rate> GetRate(IEnumerable<long> ids)
        {
            return this.context.Rates.Where(c => ids.Contains(c.Id)).ToList();
        }
        public Rate CreateRate(Rate c)
        {
            this.context.Rates.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool DeleteRate(long id)
        {
            this.context.Rates.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public Rate UpdateRate(long id, Rate newRate)
        {
            newRate.Id = id;
            this.context.Entry(newRate).State = EntityState.Modified;
            this.context.SaveChanges();

            return newRate;
        }
    }
}