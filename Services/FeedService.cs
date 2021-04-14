using System.Threading.Tasks;
using Newtonsoft.Json;
using FeedApi.Models;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Feed.Service
{
    public static class PostsService
    {
        public static async Task<FeedDTO> GetFeed(string tags = "")
        {
            FeedDTO feed = new FeedDTO();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://www.flickr.com/services/feeds/photos_public.gne?format=json&tags="+tags))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    string pureJson = Regex.Replace(apiResponse, @"^.+?\(|\)$", "");
                    feed = JsonConvert.DeserializeObject<FeedDTO>(pureJson);
                }
            }
            return feed;
        }
    }
}