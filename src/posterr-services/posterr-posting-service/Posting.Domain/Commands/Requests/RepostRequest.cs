using MediatR;

namespace Posting.Domain.Commands.Requests
{
    public class RepostRequest : IRequest<RepostResponse>
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public bool IsReposting { get; set; } = true;
    }
}
