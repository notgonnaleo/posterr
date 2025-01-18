using MediatR;

namespace Posting.Domain.Queries.Requests
{
    public class GetTrendingFeedRequest : IRequest<GetLatestFeedResponse>
    {
        public int Take { get; set; } = 20;
        public int Skip { get; set; } = 0;
    }
}
