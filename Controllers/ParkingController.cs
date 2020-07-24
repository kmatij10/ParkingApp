using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Model;

namespace ParkingApp.Controllers
{
    [ApiController]
    [Route("/api/parking")]
    public class ParkingController: AppController
    {
        private ParkingContext context;
        public ParkingController(ParkingContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            var cars = this.context.Cars.ToList();
            return Ok(cars);
        }

        [HttpGet("{car}")]
        public ActionResult<Car> Getone(Car car)
        {
            return Ok(car);
        }
        [HttpDelete("{car}")]
        public IActionResult Deleteone(Car car)
        {
            this.context.Cars.Remove(car);
            this.context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public ActionResult<Car> CreateOne(Car car)
        {
            this.context.Cars.Add(car);
            this.context.SaveChanges();
            return Ok(car);
        }
        [HttpPatch("{id}")]
        public ActionResult<Car> UpdateOne(long id, [FromBody]Car car)
        {
            //this.context.Cars.Update(car);
            //return Ok();
            return null;
        }
    }
}