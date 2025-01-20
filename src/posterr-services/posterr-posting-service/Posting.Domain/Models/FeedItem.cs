namespace Posting.Domain.Models
{
    public class FeedItem
    {
        public int PostId { get; set; }
        public string PostContent { get; set; } = string.Empty;
        public int TotalReposts { get; set; }
        public DateTime DateCreated { get; set; }
        public int PostUserId { get; set; }
        public string PostUsername { get; set; }
        public int RepostId { get; set; }
        public int RepostUserId { get; set; }
        public string RepostUsername { get; set; } = string.Empty;
        public DateTime RepostDate { get; set; }
        public bool IsRepost { get; set; }
    }
}
