using System;
using System.Collections.Generic;

namespace FeedApi.Models
{
    public class FeedDTO
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public string Generator { get; set; }
        public List<PostItemDTO> Items { get; set; }
    }
}