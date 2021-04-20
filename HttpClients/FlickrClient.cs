using System.Net.Http;
using System.Threading.Tasks;
using BaseClient.Abstractions;
using FeedApi.Models;

namespace BaseClient
{
    public class FlickrClient : HttpBaseClient, IFlickrClient
    {
        public FlickrClient(HttpClient httpClient) : base(httpClient)
        { }

        public Task<FeedDTO> GetFeed(string path)
        {
            return GetAsync<FeedDTO>(path);
        }
    }

    public interface IFlickrClient
    {
        Task<FeedDTO> GetFeed(string path);
    }
}