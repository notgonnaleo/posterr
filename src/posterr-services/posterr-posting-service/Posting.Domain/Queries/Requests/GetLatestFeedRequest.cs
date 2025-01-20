using MediatR;
using Posting.Domain.Models;
using Posting.Domain.Queries.Responses;

namespace Posting.Domain.Queries.Requests
{
    public class GetLatestFeedRequest : IRequest<GetLatestFeedResponse>
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
