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
            var feedItems = new List<FeedItem>();
            var postThumbnails = await _postRepository.GetPostThumbnails(request.Take, request.Skip);

            // If we don't have anything posted yet, let's just return an empty list
            // the UI will know what it must do when this happens, it shouldn't be a problem.
            if(!postThumbnails.Any())
            {
                return feedItems;
            }

            var mappedFeedItemsByAscendingTotalReposts = postThumbnails.Select(post => new FeedItem(post)).OrderBy(x => x.TotalReposts);
            return mappedFeedItemsByAscendingTotalReposts;
        }
    }
}
