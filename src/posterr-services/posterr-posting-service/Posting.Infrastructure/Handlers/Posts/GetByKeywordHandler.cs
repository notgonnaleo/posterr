using MediatR;
using Posting.Domain.Interfaces.Repositories;
using Posting.Domain.Models;
using Posting.Domain.Queries.Requests;

namespace Posting.Infrastructure.Handlers.Posts
{
    public class GetByKeywordHandler : IRequestHandler<GetByKeywordRequest, IEnumerable<FeedItem>>
    {
        private readonly IPostRepository _postRepository;

        public GetByKeywordHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<FeedItem>> Handle(GetByKeywordRequest request, CancellationToken cancellationToken)
        {
            var items = await _postRepository.GetByKeyword(request.Keyword);
            return items;
        }

    }
}
