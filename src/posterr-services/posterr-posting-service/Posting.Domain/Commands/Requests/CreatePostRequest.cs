using MediatR;
using Posting.Domain.Models;

namespace Posting.Domain.Commands.Requests
{
    public class CreatePostRequest : IRequest<bool>
    {
        public int AuthorId { get; set; }
        public string PostContent { get; set; }
    }
}
