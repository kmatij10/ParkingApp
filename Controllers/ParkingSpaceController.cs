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
    [Route("api/parkingspace")]
    public class ParkingSpaceController : AppController
    {
        private readonly IParkingSpaceRepository parkingSpaceRepository;
        private readonly IMapper mapper;

        public ParkingSpaceController(
            IParkingSpaceRepository parkingSpaceRepository,
            IMapper mapper
        )
        {
            this.parkingSpaceRepository = parkingSpaceRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ParkingSpaceDetailDTO>> GetParkingSpace()
        {
            var parkingSpace = this.parkingSpaceRepository.GetAll();
            var parkingSpaceDTO = this.mapper.Map<IEnumerable<ParkingSpaceDetailDTO>>(parkingSpace);
            return Ok(parkingSpaceDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<ParkingSpaceDetailDTO> GetParkingSpace(long id)
        {
            var parkingSpace = this.parkingSpaceRepository.GetOne(id);
            var parkingSpaceDTO = this.mapper.Map<ParkingSpaceDetailDTO>(parkingSpace);
            return Ok(parkingSpaceDTO);
        }
        [HttpPost]
        public ActionResult<ParkingSpaceDetailDTO> CreateParkingSpace(ParkingSpaceCreateDTO parkingSpaceDTO)
        {
            var parkingSpace = this.mapper.Map<ParkingSpace>(parkingSpaceDTO);
            parkingSpace = this.parkingSpaceRepository.CreateParkingSpace(parkingSpace);
            return this.mapper.Map<ParkingSpaceDetailDTO>(parkingSpace);
        }
        [HttpDelete("{id}")]
        public ActionResult<object> DeleteParkingSpace(long id)
        {
            return new { success = this.parkingSpaceRepository.DeleteParkingSpace(id) };
        }
        [HttpPut("{id}")]
        public ActionResult<ParkingSpaceDetailDTO> UpdateParkingSpace(long id, [FromBody] ParkingSpace updatedParkingSpace)
        {
            var parkingSpace = this.parkingSpaceRepository.UpdateParkingSpace(id, updatedParkingSpace);
            var parkingSpaceResult = this.mapper.Map<ParkingSpaceDetailDTO>(parkingSpace);
            return parkingSpaceResult;
        }
    }
}