using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public class ParkingSpaceRepository : IParkingSpaceRepository
    {
        private readonly ParkingContext context;

        public ParkingSpaceRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<ParkingSpace> GetAll()
        {
            return this.context.ParkingSpaces.ToList();
        }
        public ParkingSpace GetOne(long id)
        {
            return this.context.ParkingSpaces.Where(c => c.Id == id).Single();
        }

        public IEnumerable<ParkingSpace> GetParkingSpace(IEnumerable<long> ids)
        {
            return this.context.ParkingSpaces.Where(c => ids.Contains(c.Id)).ToList();
        }
        public ParkingSpace CreateParkingSpace(ParkingSpace c)
        {
            this.context.ParkingSpaces.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool DeleteParkingSpace(long id)
        {
            this.context.ParkingSpaces.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public ParkingSpace UpdateParkingSpace(long id, ParkingSpace newParkingSpace)
        {
            newParkingSpace.Id = id;
            this.context.Entry(newParkingSpace).State = EntityState.Modified;
            this.context.SaveChanges();

            return newParkingSpace;
        }
    }
}