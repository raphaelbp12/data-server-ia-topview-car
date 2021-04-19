using System.Threading.Tasks;
using FeedApi.Models;

namespace IService
{
    public interface IFeedService
    {
        Task<FeedDTO> GetFeed(string tags = "");
    }
}