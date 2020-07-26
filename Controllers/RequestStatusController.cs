using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Model;
using ParkingApp.Model.DTO;
using ParkingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Controllers
{
    [ApiController]
    [Route("api/requeststatus")]
    public class RequestStatusController : AppController
    {
        private readonly IRequestStatusRepository requestStatusRepository;
        private readonly IMapper mapper;

        public RequestStatusController(
            IRequestStatusRepository requestStatusRepository,
            IMapper mapper
        )
        {
            this.requestStatusRepository = requestStatusRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RequestStatusDetailDTO>> GetRequestStatus()
        {
            var requestStatus = this.requestStatusRepository.GetAll();
            var requestStatusDTO = this.mapper.Map<IEnumerable<RequestStatusDetailDTO>>(requestStatus);
            return Ok(requestStatusDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<RequestStatusDetailDTO> GetRequestStatus(long id)
        {
            var requestStatus = this.requestStatusRepository.GetOne(id);
            var requestStatusDTO = this.mapper.Map<RequestStatusDetailDTO>(requestStatus);
            return Ok(requestStatusDTO);
        }
        [HttpPost]
        public ActionResult<RequestStatusDetailDTO> CreateRequestStatus(RequestStatusCreateDTO requestStatusDTO)
        {
            var requestStatus = this.mapper.Map<RequestStatus>(requestStatusDTO);
            requestStatus = this.requestStatusRepository.CreateRequestStatus(requestStatus);
            return this.mapper.Map<RequestStatusDetailDTO>(requestStatus);
        }
        [HttpDelete("{id}")]
        public ActionResult<object> DeleteRequestStatus(long id)
        {
            return new { success = this.requestStatusRepository.DeleteRequestStatus(id) };
        }
        [HttpPut("{id}")]
        public ActionResult<RequestStatusDetailDTO> UpdateRequestStatus(long id, [FromBody] RequestStatus updatedRequestStatus)
        {
            var requestStatus = this.requestStatusRepository.UpdateRequestStatus(id, updatedRequestStatus);
            var requestStatusResult = this.mapper.Map<RequestStatusDetailDTO>(requestStatus);
            return requestStatusResult;
        }
    }
}