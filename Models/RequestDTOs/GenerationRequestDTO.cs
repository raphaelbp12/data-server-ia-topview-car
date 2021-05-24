using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    public class GenerationRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PopulationId { get; set; }
        public List<CarRequestDTO> Cars { get; set; }
    }
}
