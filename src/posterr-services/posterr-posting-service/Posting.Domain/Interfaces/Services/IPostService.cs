using Posting.Domain.Entities;
using Posting.Domain.Models;

namespace Posting.Domain.Interfaces.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostThumbnail>> GetLatestPosts(int take, int skip);
    }
}
