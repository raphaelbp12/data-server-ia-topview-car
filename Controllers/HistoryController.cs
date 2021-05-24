using Microsoft.AspNetCore.Mvc;
using DatabaseModels;
using System.Linq;
using System.Collections.Generic;
using System;

namespace FeedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly CarContext _context;
        public HistoryController(CarContext context)
        {
            _context = context;
        }

        // GET: api/History
        [HttpGet]
        public IEnumerable<PopulationResponseDTO> Get()
        {
            return _context.Populations.ToList().Select(pop => {
                List<GenerationModel> gens = _context.PopulationGenerations.Where(x => x.Population.Id == pop.Id).Select(y => y.Generation).ToList();

                return new PopulationResponseDTO
                {
                    Id = pop.Id,
                    Name = pop.Name,
                    CreatedAt = pop.CreatedAt,
                    Generations = gens.Select(gen => {
                        List<CarModel> cars = _context.GenerationCars.Where(x => x.Generation.Id == gen.Id).Select(y => y.Car).ToList();

                        return new GenerationResponseDTO
                        {
                            Id = gen.Id,
                            Name = gen.Name,
                            CreatedAt = gen.CreatedAt,
                            Cars = cars.Select(car => {
                                List<ScoreModel> scores = _context.CarScores.Where(x => x.Car.Id == car.Id).Select(y => y.Score).ToList();

                                return new CarResponseDTO
                                {
                                    Id = car.Id,
                                    Name = car.Name,
                                    Weights = car.Weights,
                                    CreatedAt = car.CreatedAt,
                                    Scores = scores
                                };
                            }).ToList()
                        };
                    }).ToList()
                };
            });
        }

        // GET: api/cars/1
        [HttpGet("{id}")]
        public PopulationModel Get(int id)
        {
            return _context.Populations.FirstOrDefault(x => x.Id == id);
        }

        // POST: api/cars
        [HttpPost]
        public IEnumerable<PopulationResponseDTO> Post([FromBody]HistoryFilterDTO filter)
        {
            return _context.Populations.Where(pop => filter.popIds.Count == 0 || filter.popIds.Contains(pop.Id)).ToList().Select(pop => {
                List<GenerationModel> gens = _context.PopulationGenerations.Where(x => x.Population.Id == pop.Id).Select(y => y.Generation).Where(gen => filter.genIds.Count == 0 || filter.genIds.Contains(gen.Id)).ToList();

                return new PopulationResponseDTO
                {
                    Id = pop.Id,
                    Name = pop.Name,
                    CreatedAt = pop.CreatedAt,
                    Generations = gens.Select(gen => {
                        List<CarModel> cars = _context.GenerationCars.Where(x => x.Generation.Id == gen.Id).Select(y => y.Car).Where(car => filter.carIds.Count == 0 || filter.carIds.Contains(car.Id)).ToList();

                        return new GenerationResponseDTO
                        {
                            Id = gen.Id,
                            Name = gen.Name,
                            CreatedAt = gen.CreatedAt,
                            Cars = cars.Select(car => {
                                List<ScoreModel> scores = _context.CarScores.Where(x => x.Car.Id == car.Id).Select(y => y.Score).Where(scr => filter.trackIds.Count == 0 || filter.trackIds.Contains(scr.TrackId)).ToList();

                                return new CarResponseDTO
                                {
                                    Id = car.Id,
                                    Name = car.Name,
                                    Weights = car.Weights,
                                    CreatedAt = car.CreatedAt,
                                    Scores = scores
                                };
                            }).ToList()
                        };
                    }).ToList()
                };
            });
        }
    }
}