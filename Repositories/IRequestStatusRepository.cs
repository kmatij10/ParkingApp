using System.Collections.Generic;
using ParkingApp.Model;

namespace ParkingApp.Repositories
{
    public interface IRequestStatusRepository
    {
        public RequestStatus GetOne(long id);
        public IEnumerable<RequestStatus> GetAll();
        public IEnumerable<RequestStatus> GetRequestStatus(IEnumerable<long> ids);
        public RequestStatus CreateRequestStatus(RequestStatus requestStatus);
        public bool DeleteRequestStatus(long id);
        public RequestStatus UpdateRequestStatus(long id, RequestStatus newRequestStatus);
    }
}