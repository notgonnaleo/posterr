using MediatR;
using Posting.Domain.Models;

namespace Posting.Domain.Queries.Requests
{
    public class GetTrendingFeedRequest : IRequest<IEnumerable<FeedItem>>
    {
        public GetTrendingFeedRequest(int take, int skip)
        {
            Take = take;
            Skip = skip;
        }
        public int Take { get; set; } = 20;
        public int Skip { get; set; } = 0;
    }
}
