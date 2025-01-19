using Posting.Domain.Models;

namespace Posting.Domain.Queries.Requests
{
    public class GetTrendingFeedResponse
    {
        public IEnumerable<FeedItem> FeedItems { get; set; }
    }
}
