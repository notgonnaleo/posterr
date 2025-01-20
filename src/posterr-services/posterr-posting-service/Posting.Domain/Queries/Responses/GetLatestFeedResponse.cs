using Posting.Domain.Models;

namespace Posting.Domain.Queries.Responses
{
    public class GetLatestFeedResponse
    {
        public IEnumerable<FeedItem> FeedItems { get; set; }
        public Pagination Pagination { get; set; }
    }
}
