using MediatR;
using Posting.Domain.Queries.Responses;

namespace Posting.Domain.Queries.Requests
{
    public class GetLatestFeedRequest : IRequest<GetLatestFeedResponse>
    {
        public int Take { get; set; } = 20;
        public int Skip { get; set; } = 0;
    }
}
