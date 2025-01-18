namespace Posting.Domain.Models
{
    public class RepostThumbnail
    {
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public DateTime DateCreated { get; set; }
        public int ParentPostTotalReposts { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public int RepostUserId { get; set; }
        public string RepostUsername { get; set; }

        public DateTime RepostDate { get; set; }

    }
}
