namespace Posting.Domain.Models
{
    public class PostThumbnail
    {
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public int TotalReposts { get; set; }
        public DateTime DateCreated { get; set; }

        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
