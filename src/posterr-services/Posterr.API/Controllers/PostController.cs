using Microsoft.AspNetCore.Mvc;
using Posterr.Domain.Entities;
using Posterr.Domain.Interfaces;
using Posterr.Domain.Models;
using Posterr.Infrastructure.Contexts;

namespace Posterr.API.Controllers
{
    [ApiController]
    [Route("api/Posts")]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context; // Remove it later
        private readonly IPostService _postService;

        public PostController(AppDbContext appDbContext, IPostService postService)
        {
            _context = appDbContext;
            _postService = postService;
        }

        [HttpGet]
        [Route("Feed")]
        public async Task<ActionResult<IEnumerable<Feed>>> GetPosts()
        {
            _context.Posts.Add(new Post()
            {
                PostId = 1,
                PostContent = "Test"
            });
            await _context.SaveChangesAsync();

            var items = await _postService.GetPosts();
            return Ok(items);
        }
    }
}
