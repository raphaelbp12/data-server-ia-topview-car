using System;
using System.Collections.Generic;
namespace DatabaseModels
{
    public class CarModel
    {
        public int Id { get; set; }
        public int PopulationId { get; set; }
        public int GenerationOrigin { get; set; }
        public string Name { get; set; }
        public string Weights {get; set; }
        public List<int> Parents { get; set; }
    }
}