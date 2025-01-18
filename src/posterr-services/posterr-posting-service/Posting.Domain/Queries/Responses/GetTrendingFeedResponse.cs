using Posting.Domain.Models;

namespace Posting.Domain.Queries.Requests
{
    public class GetLatestFeedResponse
    {
        public IEnumerable<FeedItem> FeedItems { get; set; }
    }
}
