using Posting.Domain.Entities;
using Posting.Domain.Models;

namespace Posting.Domain.Interfaces.Services
{
    public interface IPostService
    {
        Task<Post?> GetPostById(int postId);
        Task<IEnumerable<Post>?> GetPostsByUserId(int userId);
        Task<IEnumerable<PostThumbnail>> GetPostThumbnails(int take, int skip);
        Task<IEnumerable<PostThumbnail>> GetLatestPosts(int take, int skip);
        Task<bool> CreatePost(Post request, CancellationToken cancellationToken);
        Task<bool> UpdatePost(Post post, CancellationToken cancellationToken);
    }
}
