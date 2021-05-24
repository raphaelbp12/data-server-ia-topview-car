using System;
using System.Collections.Generic;
namespace DatabaseModels
{
    public class PopulationGenerationModel
    {
        public int Id { get; set; }
        public PopulationModel Population { get; set; }
        public GenerationModel Generation { get; set; }
    }
}