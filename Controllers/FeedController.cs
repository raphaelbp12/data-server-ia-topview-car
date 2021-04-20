using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeedApi.Models;
using Services.IService;

namespace FeedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IFeedService _feedService;
        public FeedController(IFeedService feedService)
        {
            _feedService = feedService;
        }
        // GET: api/Feed
        [HttpGet]
        public async Task<FeedDTO> GetFeed(string tags)
        {
            return await _feedService.GetFeed(tags);
        }
    }
}