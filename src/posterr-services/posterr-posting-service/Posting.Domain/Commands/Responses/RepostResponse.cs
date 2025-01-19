namespace Posting.Domain.Commands.Requests
{
    public class RepostResponse
    {
        public int PostId { get; set; }
        public int? RepostId { get; set; }
        public bool Reposted { get; set; }
    }
}
