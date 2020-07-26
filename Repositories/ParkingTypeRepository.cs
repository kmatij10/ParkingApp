using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public class ParkingTypeRepository : IParkingTypeRepository
    {
        private readonly ParkingContext context;

        public ParkingTypeRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<ParkingType> GetAll()
        {
            return this.context.ParkingTypes.ToList();
        }
        public ParkingType GetOne(long id)
        {
            return this.context.ParkingTypes.Where(c => c.Id == id).Single();
        }

        public IEnumerable<ParkingType> GetParkingType(IEnumerable<long> ids)
        {
            return this.context.ParkingTypes.Where(c => ids.Contains(c.Id)).ToList();
        }
        public ParkingType CreateParkingType(ParkingType c)
        {
            this.context.ParkingTypes.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool DeleteParkingType(long id)
        {
            this.context.ParkingTypes.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public ParkingType UpdateParkingType(long id, ParkingType newParkingType)
        {
            newParkingType.Id = id;
            this.context.Entry(newParkingType).State = EntityState.Modified;
            this.context.SaveChanges();

            return newParkingType;
        }
    }
}