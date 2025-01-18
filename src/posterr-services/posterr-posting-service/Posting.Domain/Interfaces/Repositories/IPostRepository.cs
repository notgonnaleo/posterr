using Posting.Domain.Entities;
using Posting.Domain.Models;

namespace Posting.Domain.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostThumbnail>> GetLatestPosts(int take, int skip);
        Task<bool> CreatePost(Post request, CancellationToken cancellationToken);

    }
}
