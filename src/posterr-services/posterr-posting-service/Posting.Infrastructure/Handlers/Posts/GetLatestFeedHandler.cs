using MediatR;
using Posting.Domain.Interfaces.Repositories;
using Posting.Domain.Models;
using Posting.Domain.Queries.Requests;

namespace Posting.Infrastructure.Handlers.Posts
{
    public class GetLatestFeedHandler : IRequestHandler<GetLatestFeedRequest, IEnumerable<FeedItem>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IRepostRepository _repostRepository;

        public GetLatestFeedHandler(IPostRepository postRepository, IRepostRepository repostRepository)
        {
            _postRepository = postRepository;
            _repostRepository = repostRepository;
        }

        public async Task<IEnumerable<FeedItem>> Handle(GetLatestFeedRequest request, CancellationToken cancellationToken)
        {
            var latestItems = await _postRepository.GetLatestFeed(request.Take, request.Skip);
            return latestItems;
        }

    }
}
