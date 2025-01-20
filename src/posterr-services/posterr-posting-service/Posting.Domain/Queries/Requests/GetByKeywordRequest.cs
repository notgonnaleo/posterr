using MediatR;
using Posting.Domain.Models;

namespace Posting.Domain.Queries.Requests
{
    public class GetByKeywordRequest : IRequest<IEnumerable<FeedItem>>
    {
        public string Keyword { get; set; }
    }
}
