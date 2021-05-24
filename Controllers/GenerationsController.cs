using Microsoft.AspNetCore.Mvc;
using DatabaseModels;
using System.Linq;
using System.Collections.Generic;
using System;

namespace FeedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerationsController : ControllerBase
    {
        private readonly CarContext _context;
        public GenerationsController(CarContext context)
        {
            _context = context;
        }

        // GET: api/cars
        [HttpGet]
        public IEnumerable<GenerationModel> Get()
        {
            return _context.Generations.ToList();
        }

        // GET: api/cars/1
        [HttpGet("{id}")]
        public GenerationModel Get(int id)
        {
            return _context.Generations.FirstOrDefault(x => x.Id == id);
        }

        // POST: api/cars
        [HttpPost]
        public IActionResult Post([FromBody]GenerationRequestDTO value)
        {
            GenerationModel generationModel = new GenerationModel();
            generationModel.Name = value.Name;
            generationModel.CreatedAt = DateTime.Now;
            _context.Generations.Add(generationModel);
            // _context.SaveChanges();

            if (value.Cars.Count > 0) {
                foreach (var carDTO in value.Cars)
                {
                    CarModel carModel = new CarModel
                    {
                        Name = carDTO.Name,
                        Weights = carDTO.Weights,
                        CreatedAt = DateTime.Now
                    };

                    if(_context.Cars.FirstOrDefault(car => car.Name == carModel.Name) == null) {
                        _context.Cars.Add(carModel);

                        CarModel motherCar = _context.Cars.FirstOrDefault(car => car.Name == carDTO.MotherName);
                        CarModel fatherCar = _context.Cars.FirstOrDefault(car => car.Name == carDTO.FatherName);

                        if (motherCar != null && fatherCar != null)
                        {
                            _context.Parents.Add(new ParentsModel{ Child = carModel, Father = fatherCar, Mother = motherCar });
                        }
                    }
                    // _context.SaveChanges();

                    _context.GenerationCars.Add(new GenerationCarModel{ Car = carModel, Generation = generationModel });
                    // _context.SaveChanges();

                    foreach (var score in carDTO.Scores)
                    {
                        ScoreModel scoreModel = new ScoreModel{
                            TrackId = score.TrackId,
                            Value = score.Value,
                            CreatedAt = DateTime.Now
                        };

                        _context.Scores.Add(scoreModel);
                        // _context.SaveChanges();

                        _context.CarScores.Add(new CarScoreModel{ Car = carModel, Score = scoreModel });
                        // _context.SaveChanges();
                    }
                }
            }

            PopulationGenerationModel populationGenerationModel = new PopulationGenerationModel();
            populationGenerationModel.Generation = generationModel;
            populationGenerationModel.Population = _context.Populations.FirstOrDefault(x => x.Id == value.PopulationId);
            _context.PopulationGenerations.Add(populationGenerationModel);

            _context.SaveChanges();
            return StatusCode(201, generationModel);
        }
    }
}