using MediatR;
using Posting.Domain.Interfaces.Repositories;
using Posting.Domain.Interfaces.Services;
using Posting.Domain.Models;
using Posting.Domain.Queries.Requests;
using Posting.Domain.Queries.Responses;

namespace Posting.Infrastructure.Handlers.Posts
{
    public class GetLatestFeedHandler : IRequestHandler<GetLatestFeedRequest, List<FeedItem>>
    {
        private readonly IPostService _postService;
        private readonly IRepostRepository _repostRepository;

        public GetLatestFeedHandler(IPostService postService, IRepostRepository repostRepository)
        {
            _postService = postService;
            _repostRepository = repostRepository;
        }

        public async Task<List<FeedItem>> Handle(GetLatestFeedRequest request, CancellationToken cancellationToken)
        {
            var feedItems = new List<FeedItem>();

            var latestPosts = await _postService.GetLatestPosts(request.Take, request.Skip);
            var latestReposts = await _repostRepository.GetLatestReposts(request.Take, request.Skip);

            if (latestPosts != null && latestPosts.Any() && latestReposts != null && latestReposts.Any())
            {
                var mappedPostToFeedItem = latestPosts.Select(feedItem => new FeedItem(feedItem));
                var mappedRepostToFeedItem = latestReposts.Select(feedItem => new FeedItem(feedItem));
                feedItems.AddRange(mappedPostToFeedItem);
                feedItems.AddRange(mappedRepostToFeedItem);
            }

            // Re-ordering from the latest to oldest posts & reposts
            // to make sure our list is going to be accurate.
            feedItems.OrderByDescending(x => x.PostDate).ThenByDescending(x => x.RepostDate);

            return feedItems;
        }
    }
}
