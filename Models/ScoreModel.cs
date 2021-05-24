using System;
using System.Collections.Generic;
namespace DatabaseModels
{
    public class ScoreModel
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public float Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}