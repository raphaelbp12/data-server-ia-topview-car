using Microsoft.AspNetCore.Mvc;
using DatabaseModels;
using System.Linq;
using System.Collections.Generic;

namespace FeedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarContext _context;
        public CarsController(CarContext context)
        {
            _context = context;
        }

        // GET: api/cars
        [HttpGet]
        public IEnumerable<CarModel> Get()
        {
            return _context.Cars.ToList();
        }

        // GET: api/cars/1
        [HttpGet("{id}")]
        public CarModel Get(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }

        // POST: api/cars
        [HttpPost]
        public IActionResult Post([FromBody]CarModel value)
        {
            _context.Cars.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }
    }
}