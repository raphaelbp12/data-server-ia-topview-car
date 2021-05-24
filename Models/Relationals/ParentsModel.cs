using System;
using System.Collections.Generic;
namespace DatabaseModels
{
    public class ParentsModel
    {
        public int Id { get; set; }
        public CarModel Child { get; set; }
        public CarModel Mother { get; set; }
        public CarModel Father { get; set; }
    }
}