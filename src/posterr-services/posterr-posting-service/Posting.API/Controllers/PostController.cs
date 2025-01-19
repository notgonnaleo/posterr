using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posting.Domain.Commands.Requests;
using Posting.Domain.Models;
using Posting.Domain.Queries.Requests;

namespace Posterr.API.Controllers
{
    [ApiController]
    [Route("api/posting")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("latest")]
        public async Task<ActionResult<IEnumerable<FeedItem>>> GeLatestFeed(int take, int skip)
        {
            try
            {
                var request = new GetLatestFeedRequest(take, skip);
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("trending")]
        public async Task<ActionResult<IEnumerable<FeedItem>>> GetTrendingFeed(int take, int skip)
        {
            try
            {
                var request = new GetTrendingFeedRequest(take, skip);
                var response = await _mediator.Send(request);
                return Ok(response.FeedItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<bool>> CreatePost(CreatePostRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("repost")]
        public async Task<ActionResult<bool>> Repost(RepostRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
