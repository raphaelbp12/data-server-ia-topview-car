using System;

namespace FeedApi.Models
{
    public class MediaDTO
    {
        public string m { get; set; }
    }
    public class PostItemDTO
    {
        public string title { get; set; }
        public string link { get; set; }
        public MediaDTO media { get; set; }
        public DateTime date_taken { get; set; }
        public string description { get; set; }
        public DateTime published { get; set; }
        public string author { get; set; }
        public string author_id { get; set; }
        public string tags { get; set; }
    }
}