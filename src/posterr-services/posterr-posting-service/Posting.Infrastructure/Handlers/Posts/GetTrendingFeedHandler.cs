using MediatR;
using Posting.Domain.Interfaces.Repositories;
using Posting.Domain.Models;
using Posting.Domain.Queries.Requests;

namespace Posting.Infrastructure.Handlers.Posts
{
    public class GetTrendingFeedHandler : IRequestHandler<GetTrendingFeedRequest, IEnumerable<FeedItem>>
    {
        private readonly IPostRepository _postRepository;
        public GetTrendingFeedHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<IEnumerable<FeedItem>> Handle(GetTrendingFeedRequest request, CancellationToken cancellationToken)
        {
            var trendingPosts = await _postRepository.GetTrendingFeed(request.Take, request.Skip);
            return trendingPosts;
        }
    }
}
