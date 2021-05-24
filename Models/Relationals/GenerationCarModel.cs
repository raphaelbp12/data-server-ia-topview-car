using System;
using System.Collections.Generic;
namespace DatabaseModels
{
    public class GenerationCarModel
    {
        public int Id { get; set; }
        public GenerationModel Generation { get; set; }
        public CarModel Car { get; set; }
    }
}