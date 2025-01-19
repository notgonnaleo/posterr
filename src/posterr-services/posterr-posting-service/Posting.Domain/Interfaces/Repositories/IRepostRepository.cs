using Posting.Domain.Entities;
using Posting.Domain.Models;

namespace Posting.Domain.Interfaces.Repositories
{
    public interface IRepostRepository
    {
        Task<IEnumerable<RepostThumbnail>> GetLatestReposts(int take, int skip);
        Task<bool> CreateRepost(Repost request, CancellationToken cancellationToken);
    }
}
