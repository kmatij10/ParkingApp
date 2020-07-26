using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private readonly ParkingContext context;

        public RequestStatusRepository(ParkingContext context)
        {
            this.context = context;
        }

        public IEnumerable<RequestStatus> GetAll()
        {
            return this.context.RequestStatuses.ToList();
        }
        public RequestStatus GetOne(long id)
        {
            return this.context.RequestStatuses.Where(c => c.Id == id).Single();
        }

        public IEnumerable<RequestStatus> GetRequestStatus(IEnumerable<long> ids)
        {
            return this.context.RequestStatuses.Where(c => ids.Contains(c.Id)).ToList();
        }
        public RequestStatus CreateRequestStatus(RequestStatus c)
        {
            this.context.RequestStatuses.Add(c);
            this.context.SaveChanges();

            return c;
        }
        public bool DeleteRequestStatus(long id)
        {
            this.context.RequestStatuses.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }
        public RequestStatus UpdateRequestStatus(long id, RequestStatus newRequestStatus)
        {
            newRequestStatus.Id = id;
            this.context.Entry(newRequestStatus).State = EntityState.Modified;
            this.context.SaveChanges();

            return newRequestStatus;
        }
    }
}