using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class CarRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Weights { get; set; }
        public List<ScoreRequestDTO> Scores { get; set; } = new List<ScoreRequestDTO>();
    }
}
