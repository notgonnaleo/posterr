namespace Posting.Domain.Models
{
    public class RepostThumbnail
    {
        public int PostId { get; set; }
        public int RepostId { get; set; }
        public int RepostUserId { get; set; }
        public string RepostUsername { get; set; }
        public DateTime RepostDate { get; set; }
        public int TotalRowCount { get; set; }
    }
}
