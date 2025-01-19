using MediatR;
using Posting.Domain.Models;

namespace Posting.Domain.Queries.Requests
{
    public class GetLatestFeedRequest : IRequest<List<FeedItem>>
    {
        public GetLatestFeedRequest(int take, int skip)
        {
            Take = take;
            Skip = skip;
        }
        public int Take { get; set; } = 20;
        public int Skip { get; set; } = 0;
    }
}
