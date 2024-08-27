using CargoLoadAPI.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        // POST: api/CargoLoads
        [HttpPost]
        public ActionResult Post([FromBody] CargoLoad load)
        {
            load.Id = CargoLoads.Count + 1;
            CargoLoads.Add(load);
            return Ok(load);
        }
    }
}
