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
            return new GetTrendingFeedResponse();
        }
    }
}
