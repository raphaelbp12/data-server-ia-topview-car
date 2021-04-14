using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeedApi.Models;

namespace FeedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        // GET: api/Feed
        [HttpGet]
        public async Task<ActionResult<FeedDTO>> GetFeed(string tags)
        {
            return await Feed.Service.PostsService.GetFeed(tags);
        }
    }
}