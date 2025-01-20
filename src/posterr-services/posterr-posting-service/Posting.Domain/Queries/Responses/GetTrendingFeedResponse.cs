using Posting.Domain.Models;

namespace Posting.Domain.Queries.Requests
{
    public class GetTrendingFeedResponse
    {
        public IEnumerable<FeedItem2> FeedItems { get; set; }
        public Pagination Pagination { get; set; }
    }
}
