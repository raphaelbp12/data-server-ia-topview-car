using System;
using System.Collections.Generic;
namespace DatabaseModels
{
    public class HistoryFilterDTO
    {
        public List<int> popIds { get; set; } = new List<int>();
        public List<int> genIds { get; set; } = new List<int>();
        public List<int> carIds { get; set; } = new List<int>();
        public List<int> trackIds { get; set; } = new List<int>();
    }
}