using System;
using System.Collections.Generic;
namespace DatabaseModels
{
    public class CarResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weights {get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ScoreModel> Scores { get; set; }

        public List<CarModel> Parents { get; set; }
    }
}