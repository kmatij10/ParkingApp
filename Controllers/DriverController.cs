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
    [Route("api/driver")]
    public class DriverController : AppController
    {
        private readonly IDriverRepository driverRepository;
        private readonly IMapper mapper;

        public DriverController(
            IDriverRepository driverRepository,
            IMapper mapper
        )
        {
            this.driverRepository = driverRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DriverDetailDTO>> GetDriver()
        {
            var driver = this.driverRepository.GetAll();
            var driverDTO = this.mapper.Map<IEnumerable<DriverDetailDTO>>(driver);
            return Ok(driverDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<DriverDetailDTO> GetDriver(long id)
        {
            var driver = this.driverRepository.GetOne(id);
            var driverDTO = this.mapper.Map<DriverDetailDTO>(driver);
            return Ok(driverDTO);
        }

        [HttpPost]
        public ActionResult<DriverDetailDTO> CreateDriver(DriverCreateDTO driverDTO)
        {
            var driver = this.mapper.Map<Driver>(driverDTO);
            driver = this.driverRepository.CreateDriver(driver);
            return this.mapper.Map<DriverDetailDTO>(driver);
        }

        [HttpDelete("{id}")]
        public ActionResult<object> DeleteDriver(long id)
        {
            return new { success = this.driverRepository.DeleteDriver(id) };
        }

        [HttpPut("{id}")]
        public ActionResult<DriverDetailDTO> UpdateDriver(long id, [FromBody] Driver updatedDriver)
        {
            var driver = this.driverRepository.UpdateDriver(id, updatedDriver);
            var driverResult = this.mapper.Map<DriverDetailDTO>(driver);
            return driverResult;
        }
    }
}