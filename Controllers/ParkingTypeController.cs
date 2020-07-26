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
    [Route("api/parkingtype")]
    public class ParkingTypeController : AppController
    {
        private readonly IParkingTypeRepository parkingTypeRepository;
        private readonly IMapper mapper;

        public ParkingTypeController(
            IParkingTypeRepository parkingTypeRepository,
            IMapper mapper
        )
        {
            this.parkingTypeRepository = parkingTypeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ParkingTypeDetailDTO>> GetParkingType()
        {
            var parkingType = this.parkingTypeRepository.GetAll();
            var parkingTypeDTO = this.mapper.Map<IEnumerable<ParkingTypeDetailDTO>>(parkingType);
            return Ok(parkingTypeDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<ParkingTypeDetailDTO> GetParkingType(long id)
        {
            var parkingType = this.parkingTypeRepository.GetOne(id);
            var parkingTypeDTO = this.mapper.Map<ParkingTypeDetailDTO>(parkingType);
            return Ok(parkingTypeDTO);
        }
        [HttpPost]
        public ActionResult<ParkingTypeDetailDTO> CreateParkingType(ParkingTypeCreateDTO parkingTypeDTO)
        {
            var parkingType = this.mapper.Map<ParkingType>(parkingTypeDTO);
            parkingType = this.parkingTypeRepository.CreateParkingType(parkingType);
            return this.mapper.Map<ParkingTypeDetailDTO>(parkingType);
        }
        [HttpDelete("{id}")]
        public ActionResult<object> DeleteParkingType(long id)
        {
            return new { success = this.parkingTypeRepository.DeleteParkingType(id) };
        }
        [HttpPut("{id}")]
        public ActionResult<ParkingTypeDetailDTO> UpdateParkingType(long id, [FromBody] ParkingType updatedParkingType)
        {
            var parkingType = this.parkingTypeRepository.UpdateParkingType(id, updatedParkingType);
            var parkingTypeResult = this.mapper.Map<ParkingTypeDetailDTO>(parkingType);
            return parkingTypeResult;
        }
    }
}