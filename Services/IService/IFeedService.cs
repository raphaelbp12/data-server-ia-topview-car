using System.Threading.Tasks;
using FeedApi.Models;

namespace Services.IService
{
    public interface IFeedService
    {
        Task<FeedDTO> GetFeed(string tags = "");
    }
}