using CargoLoadAPI.Server.Data;
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
        private readonly CargoLoadsContext _context;

        public CargoLoadsController(CargoLoadsContext context)
        {
            _context = context;
        }

        // GET: api/CargoLoads
        [HttpGet]
        public ActionResult<IEnumerable<CargoLoad>> Get()
        {
            return Ok(_context.CargoLoads.ToList());
        }

        // GET: api/CargoLoads/{id}
        [HttpGet("{id}")]
        public ActionResult<CargoLoad> Get(int id)
        {
            var load = _context.CargoLoads.Find(id);
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
            _context.CargoLoads.Add(load);
            _context.SaveChanges();
            return Ok(load);
        }

        // PUT: api/CargoLoads/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CargoLoad updatedLoad)
        {
            var load = _context.CargoLoads.Find(id);
            if (load == null)
            {
                return NotFound();
            }

            load.DriverName = updatedLoad.DriverName;
            load.VehicleNumber = updatedLoad.VehicleNumber;
            load.VehicleType = updatedLoad.VehicleType;
            load.LoadWeight = updatedLoad.LoadWeight;
            load.IsDangerousGoods = updatedLoad.IsDangerousGoods;

            _context.SaveChanges();
            return Ok(load);
        }

        // DELETE: api/CargoLoads/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var load = _context.CargoLoads.Find(id);
            if (load == null)
            {
                return NotFound();
            }

            _context.CargoLoads.Remove(load);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
