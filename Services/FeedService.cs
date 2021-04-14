using System.Threading.Tasks;
using FeedApi.Models;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Feed.Service
{
    public class FeedService
    {
        private readonly IHttpClientFactory _clientFactory;
        public FeedService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<FeedDTO> GetFeed(string tags = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://www.flickr.com/services/feeds/photos_public.gne?format=json&tags="+tags);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            
            string apiResponse = await response.Content.ReadAsStringAsync();
            string pureJson = Regex.Replace(apiResponse, @"^.+?\(|\)$", "");
            return JsonConvert.DeserializeObject<FeedDTO>(pureJson);
        }
    }
}