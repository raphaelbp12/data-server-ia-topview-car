using System.Threading.Tasks;
using FeedApi.Models;
using BaseClient;
using Services.IService;

namespace Services.FeedService
{
    public class FeedService : IFeedService
    {
        private readonly IFlickrClient _flickrClient;
        public FeedService(IFlickrClient flickrClient)
        {
            _flickrClient = flickrClient;
        }

        public async Task<FeedDTO> GetFeed(string tags = "")
        {
            var response = await _flickrClient.GetFeed("/services/feeds/photos_public.gne?format=json&tags=" + tags);

            return response;
        }
    }
}