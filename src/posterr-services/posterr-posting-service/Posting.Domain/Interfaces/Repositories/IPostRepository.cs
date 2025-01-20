using Posting.Domain.Entities;
using Posting.Domain.Models;

namespace Posting.Domain.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<Post?> GetPostById(int postId);
        Task<IEnumerable<Post>?> GetPostsByUserId(int userId);
        Task<IEnumerable<FeedItem>> GetLatestFeed(int take, int skip);
        Task<IEnumerable<FeedItem>> GetTrendingFeed(int take, int skip);
        Task<IEnumerable<FeedItem>> GetByKeyword(string keyword);
        Task<bool> CreatePost(Post request, CancellationToken cancellationToken);
        Task<bool> UpdatePost(Post request, CancellationToken cancellationToken);
    }
}
