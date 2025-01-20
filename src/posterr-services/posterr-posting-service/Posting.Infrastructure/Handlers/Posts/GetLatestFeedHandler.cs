using MediatR;
using Posting.Domain.Interfaces.Repositories;
using Posting.Domain.Interfaces.Services;
using Posting.Domain.Models;
using Posting.Domain.Queries.Requests;
using Posting.Domain.Queries.Responses;

namespace Posting.Infrastructure.Handlers.Posts
{
    public class GetLatestFeedHandler : IRequestHandler<GetLatestFeedRequest, GetLatestFeedResponse>
    {
        private readonly IPostService _postService;
        private readonly IRepostRepository _repostRepository;

        public GetLatestFeedHandler(IPostService postService, IRepostRepository repostRepository)
        {
            _postService = postService;
            _repostRepository = repostRepository;
        }

        public async Task<GetLatestFeedResponse> Handle(GetLatestFeedRequest request, CancellationToken cancellationToken)
        {
            var feedItems = new List<FeedItem>();

            var latestPosts = await _postService.GetLatestPosts(request.Take, request.Skip);
            var latestReposts = await _repostRepository.GetLatestReposts(request.Take, request.Skip);

            // If we don't have anything posted yet, let's just return an empty list
            if (latestPosts is null || !latestPosts.Any() && latestReposts is null || !latestReposts.Any())
            {
                return new GetLatestFeedResponse()
                {
                    FeedItems = feedItems,
                    Pagination = new Pagination()
                };
            }

            var mappedPostToFeedItem = latestPosts.Select(feedItem => new FeedItem(feedItem));
            var totalPosts = mappedPostToFeedItem.First().TotalRowCount;
            
            var mappedRepostToFeedItem = latestReposts.Select(feedItem => new FeedItem(feedItem));
            var totalReposts = mappedRepostToFeedItem.First().TotalRowCount;

            var totalRowCount = totalPosts + totalReposts;

            feedItems.AddRange(mappedPostToFeedItem);
            feedItems.AddRange(mappedRepostToFeedItem);

            // This should filter the posts by the most recent created posts and reposts
            feedItems = feedItems
                .OrderByDescending(x => x.PostId)
                .ThenByDescending(x => x.RepostId)
                .ToList();

            var pagedFeedItems = feedItems
                .Skip(request.Skip) 
                .Take(request.Take) 
                .ToList();

            return new GetLatestFeedResponse()
            {
                FeedItems = pagedFeedItems,
                Pagination = new Pagination()
                {
                    Take = request.Take,
                    Skip = request.Skip,
                    TotalRowCount = totalRowCount
                }
            };
        }

    }
}
