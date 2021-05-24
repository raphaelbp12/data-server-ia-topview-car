using System;
using System.Collections.Generic;
namespace DatabaseModels
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weights {get; set; }
        public DateTime CreatedAt { get; set; }
    }
}