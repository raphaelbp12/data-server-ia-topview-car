using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostsApi.Models;

namespace PostsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        // GET: api/Feed
        [HttpGet]
        public async Task<ActionResult<FeedDTO>> GetFeed()
        {
            // return await _context.TodoItems
            //     .Select(x => ItemToDTO(x))
            //     .ToListAsync();
            return await Posts.Service.PostsService.GetFeed();
        }
    }
}