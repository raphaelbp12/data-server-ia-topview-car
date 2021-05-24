using System;
using System.Collections.Generic;
namespace DatabaseModels
{
    public class CarScoreModel
    {
        public int Id { get; set; }
        public CarModel Car { get; set; }
        public ScoreModel Score { get; set; }
    }
}