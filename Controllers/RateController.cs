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
    [Route("api/rate")]
    public class RateController : AppController
    {
        private readonly IRateRepository rateRepository;
        private readonly IMapper mapper;

        public RateController(
            IRateRepository rateRepository,
            IMapper mapper
        )
        {
            this.rateRepository = rateRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RateDetailDTO>> GetRate()
        {
            var rate = this.rateRepository.GetAll();
            var rateDTO = this.mapper.Map<IEnumerable<RateDetailDTO>>(rate);
            return Ok(rateDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<RateDetailDTO> GetRate(long id)
        {
            var rate = this.rateRepository.GetOne(id);
            var rateDTO = this.mapper.Map<RateDetailDTO>(rate);
            return Ok(rateDTO);
        }
        [HttpPost]
        public ActionResult<RateDetailDTO> CreateRate(RateCreateDTO rateDTO)
        {
            var rate = this.mapper.Map<Rate>(rateDTO);
            rate = this.rateRepository.CreateRate(rate);
            return this.mapper.Map<RateDetailDTO>(rate);
        }
        [HttpDelete("{id}")]
        public ActionResult<object> DeleteRate(long id)
        {
            return new { success = this.rateRepository.DeleteRate(id) };
        }
        [HttpPut("{id}")]
        public ActionResult<RateDetailDTO> UpdateRate(long id, [FromBody] Rate updatedRate)
        {
            var rate = this.rateRepository.UpdateRate(id, updatedRate);
            var rateResult = this.mapper.Map<RateDetailDTO>(rate);
            return rateResult;
        }
    }
}