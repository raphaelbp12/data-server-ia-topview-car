using Microsoft.AspNetCore.Mvc;
using DatabaseModels;
using System.Linq;
using System.Collections.Generic;

namespace FeedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly CarContext _context;
        public ScoresController(CarContext context)
        {
            _context = context;
        }

        // GET: api/cars
        [HttpGet]
        public IEnumerable<ScoreModel> Get()
        {
            return _context.Scores.ToList();
        }

        // GET: api/cars/1
        [HttpGet("{id}")]
        public ScoreModel Get(int id)
        {
            return _context.Scores.FirstOrDefault(x => x.Id == id);
        }

        // POST: api/cars
        [HttpPost]
        public IActionResult Post([FromBody]ScoreModel value)
        {
            _context.Scores.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }
    }
}