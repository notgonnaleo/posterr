using MediatR;

namespace Posting.Domain.Queries.Requests
{
    public class GetTrendingFeedRequest : IRequest<GetTrendingFeedResponse>
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
