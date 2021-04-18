using System.Threading.Tasks;
using FeedApi.Models;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using BaseClient;

namespace Feed.Service
{
    public class FeedService : FlickrBaseClient
    {
        public FeedService(HttpClient client) : base(client) { }
        public async Task<FeedDTO> GetFeed(string tags = "")
        {

            var response = await Client.GetAsync("/services/feeds/photos_public.gne?format=json&tags="+tags);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            
            string apiResponse = await response.Content.ReadAsStringAsync();
            string pureJson = Regex.Replace(apiResponse, @"^.+?\(|\)$", "");
            return JsonConvert.DeserializeObject<FeedDTO>(pureJson);
        }
    }
}