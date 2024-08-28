using CargoLoadAPI.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CargoLoadAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoLoadsController : ControllerBase
    {
        // In-memory storage for demonstration purposes
        private static List<CargoLoad> CargoLoads = new List<CargoLoad>();

        // GET: api/CargoLoads
        [HttpGet]
        public ActionResult<IEnumerable<CargoLoad>> Get()
        {
            return Ok(CargoLoads);
        }

        // GET: api/CargoLoads/{id}
        [HttpGet("{id}")]
        public ActionResult<CargoLoad> Get(int id)
        {
            var load = CargoLoads.FirstOrDefault(cl => cl.Id == id);
            if (load == null)
            {
                return NotFound();
            }
            return Ok(load);
        }

        // POST: api/CargoLoads
        [HttpPost]
        public ActionResult Post([FromBody] CargoLoad load)
        {
            load.Id = CargoLoads.Count + 1;
            CargoLoads.Add(load);
            return Ok(load);
        }

        // PUT: api/CargoLoads/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CargoLoad updatedLoad)
        {
            var load = CargoLoads.FirstOrDefault(cl => cl.Id == id);
            if (load == null)
            {
                return NotFound();
            }

            load.DriverName = updatedLoad.DriverName;
            load.VehicleNumber = updatedLoad.VehicleNumber;
            load.VehicleType = updatedLoad.VehicleType;
            load.LoadWeight = updatedLoad.LoadWeight;
            load.IsDangerousGoods = updatedLoad.IsDangerousGoods;

            return Ok(load);
        }

        // DELETE: api/CargoLoads/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var load = CargoLoads.FirstOrDefault(cl => cl.Id == id);
            if (load == null)
            {
                return NotFound();
            }

            CargoLoads.Remove(load);
            return NoContent();
        }
    }
}
