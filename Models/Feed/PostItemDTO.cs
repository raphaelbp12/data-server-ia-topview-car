using System;

namespace FeedApi.Models
{
    public class MediaDTO
    {
        public string M { get; set; }
    }
    public class PostItemDTO
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public MediaDTO Media { get; set; }
        public DateTime DateTaken { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public string Author { get; set; }
        public string AuthorId { get; set; }
        public string Tags { get; set; }
    }
}