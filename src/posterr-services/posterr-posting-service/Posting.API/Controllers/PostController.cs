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
            var request = new GetLatestFeedRequest();
            request.Skip = skip <= 0 ? 0 : skip;
            request.Take = take <= 0 ? 0 : take;
            var response = await _mediator.Send(request);
            return Ok(response);    
        }

        [HttpGet]
        [Route("trending")]
        public async Task<ActionResult<IEnumerable<FeedItem>>> GetTrendingFeed(int take, int skip)
        {
            var request = new GetTrendingFeedRequest();
            request.Skip = skip <= 0 ? 0 : skip;
            request.Take = take <= 0 ? 0 : take;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<bool>> CreatePost(CreatePostRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(request);
        }

        [HttpPost]
        [Route("repost")]
        public async Task<ActionResult<bool>> Repost(RepostRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(request);
        }

        [HttpGet]
        [Route("keyword")]
        public async Task<ActionResult<bool>> Keyword(string keyword)
        {
            var request = new GetByKeywordRequest();
            request.Keyword = keyword;
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
