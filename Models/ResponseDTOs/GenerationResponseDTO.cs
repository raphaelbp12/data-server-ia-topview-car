using System;
using System.Collections.Generic;
namespace DatabaseModels
{
    public class GenerationResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CarResponseDTO> Cars { get; set; }
    }
}