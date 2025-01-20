using MediatR;
using Posting.Domain.Interfaces.Repositories;
using Posting.Domain.Models;
using Posting.Domain.Queries.Requests;

namespace Posting.Infrastructure.Handlers.Posts
{
    public class GetTrendingFeedHandler : IRequestHandler<GetTrendingFeedRequest, GetTrendingFeedResponse>
    {
        private readonly IPostRepository _postRepository;
        public GetTrendingFeedHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<GetTrendingFeedResponse> Handle(GetTrendingFeedRequest request, CancellationToken cancellationToken)
        {
            var feedItems = new List<FeedItem2>();
            var postThumbnails = await _postRepository.GetPostThumbnails(request.Take, request.Skip);

            // If we don't have anything posted yet, let's just return an empty list
            // the UI will know what it must do when this happens, it shouldn't be a problem.
            if (!postThumbnails.Any())
            {
                return new GetTrendingFeedResponse() 
                {
                    FeedItems = feedItems,
                    Pagination = new Pagination()
                };
            }

            var firstItemTotalRowCounting = postThumbnails.FirstOrDefault();
            var totalRowCount = firstItemTotalRowCounting != null ? firstItemTotalRowCounting.TotalRowCount : 20;

            var mappedFeedItemsByAscendingTotalReposts = postThumbnails.Select(post => new FeedItem2(post));
            var result = mappedFeedItemsByAscendingTotalReposts.OrderByDescending(x => x.TotalReposts).ToList();

            return new GetTrendingFeedResponse() 
            {
                FeedItems = result,
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
