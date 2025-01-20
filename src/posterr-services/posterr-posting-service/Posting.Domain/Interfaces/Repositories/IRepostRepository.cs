using Posting.Domain.Entities;
using Posting.Domain.Models;

namespace Posting.Domain.Interfaces.Repositories
{
    public interface IRepostRepository
    {
        Task<int> CreateRepost(Repost request, CancellationToken cancellationToken);
        Task<bool> UpdateRepost(Repost request, CancellationToken cancellationToken);

    }
}
