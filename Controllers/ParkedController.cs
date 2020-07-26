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
    [Route("api/parked")]
    public class ParkedController : AppController
    {
        private readonly IParkedRepository parkedRepository;
        private readonly IMapper mapper;

        public ParkedController(
            IParkedRepository parkedRepository,
            IMapper mapper
        )
        {
            this.parkedRepository = parkedRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ParkedDetailDTO>> GetParked()
        {
            var parked = this.parkedRepository.GetAll();
            var parkedDTO = this.mapper.Map<IEnumerable<ParkedDetailDTO>>(parked);
            return Ok(parkedDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<ParkedDetailDTO> GetParked(long id)
        {
            var parked = this.parkedRepository.GetOne(id);
            var parkedDTO = this.mapper.Map<ParkedDetailDTO>(parked);
            return Ok(parkedDTO);
        }
        [HttpPost]
        public ActionResult<ParkedDetailDTO> CreateParked(ParkedCreateDTO parkedDTO)
        {
            var parked = this.mapper.Map<Parked>(parkedDTO);
            parked = this.parkedRepository.CreateParked(parked);
            return this.mapper.Map<ParkedDetailDTO>(parked);
        }
        [HttpDelete("{id}")]
        public ActionResult<object> DeleteParked(long id)
        {
            return new { success = this.parkedRepository.DeleteParked(id) };
        }
        [HttpPut("{id}")]
        public ActionResult<ParkedDetailDTO> UpdateParked(long id, [FromBody] Parked updatedParked)
        {
            var parked = this.parkedRepository.UpdateParked(id, updatedParked);
            var parkedResult = this.mapper.Map<ParkedDetailDTO>(parked);
            return parkedResult;
        }
    }
}