using System;
using System.Collections.Generic;

namespace FeedApi.Models
{
    public class FeedDTO
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public DateTime modified { get; set; }
        public string generator { get; set; }
        public List<PostItemDTO> items { get; set; }
    }
}