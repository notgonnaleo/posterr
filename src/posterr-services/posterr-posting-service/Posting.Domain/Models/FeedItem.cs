namespace Posting.Domain.Models
{
    public class FeedItem
    {
        public FeedItem(PostThumbnail post)
        {
            PostId = post.PostId;
            PostContent = post.PostContent;
            TotalReposts = post.TotalReposts;
            AuthorId = post.UserId;
            AuthorName = post.Username;
            PostDate = post.DateCreated;
            RepostUserId = null;
            RepostUsername = null;
            RepostDate = null;
        }

        public FeedItem(RepostThumbnail repost) 
        {
            PostId = repost.PostId;
            PostContent = repost.PostContent;
            TotalReposts = repost.ParentPostTotalReposts;
            AuthorId = repost.AuthorId;
            AuthorName = repost.AuthorName;
            PostDate = repost.DateCreated;
            RepostUserId = repost.RepostUserId;
            RepostUsername = repost.RepostUsername;
            RepostDate = repost.RepostDate;
        }

        public int PostId { get; set; }
        public string PostContent { get; set; }
        public int TotalReposts { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime PostDate { get; set; }

        public int? RepostUserId { get; set; }
        public string? RepostUsername { get; set; }
        public DateTime? RepostDate { get; set; }
    }
}
