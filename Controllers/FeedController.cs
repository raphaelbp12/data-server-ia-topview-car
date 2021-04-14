using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeedApi.Models;
using Feed.Service;

namespace FeedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        // GET: api/Feed
        [HttpGet]
        public async Task<FeedDTO> GetFeed([FromServices] FeedService feedService, string tags)
        {
            return await feedService.GetFeed(tags);
        }
    }
}