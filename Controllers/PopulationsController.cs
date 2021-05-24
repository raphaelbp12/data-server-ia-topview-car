using Microsoft.AspNetCore.Mvc;
using DatabaseModels;
using System.Linq;
using System.Collections.Generic;
using System;

namespace FeedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationsController : ControllerBase
    {
        private readonly CarContext _context;
        public PopulationsController(CarContext context)
        {
            _context = context;
        }

        // GET: api/cars
        [HttpGet]
        public IEnumerable<PopulationModel> Get()
        {
            return _context.Populations.ToList();
        }

        // GET: api/cars/1
        [HttpGet("{id}")]
        public PopulationModel Get(int id)
        {
            return _context.Populations.FirstOrDefault(x => x.Id == id);
        }

        // POST: api/cars
        [HttpPost]
        public IActionResult Post([FromBody]PopulationModel value)
        {
            value.CreatedAt = DateTime.Now;
            _context.Populations.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }
    }
}