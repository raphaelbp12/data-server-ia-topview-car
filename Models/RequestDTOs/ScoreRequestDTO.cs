using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class ScoreRequestDTO
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public float Value { get; set; }
    }
}
