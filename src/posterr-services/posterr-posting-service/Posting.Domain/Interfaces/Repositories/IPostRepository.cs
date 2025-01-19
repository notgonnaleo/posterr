using Posting.Domain.Entities;
using Posting.Domain.Models;

namespace Posting.Domain.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<Post?> GetPostById(int postId);
        Task<IEnumerable<PostThumbnail>> GetPostThumbnails(int take, int skip);
        Task<IEnumerable<PostThumbnail>> GetLatestPosts(int take, int skip);
        Task<bool> CreatePost(Post request, CancellationToken cancellationToken);
        Task<bool> UpdatePost(Post request, CancellationToken cancellationToken);
    }
}
