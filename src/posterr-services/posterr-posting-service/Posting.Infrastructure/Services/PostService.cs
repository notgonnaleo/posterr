using Posting.Domain.Entities;
using Posting.Domain.Interfaces.Repositories;
using Posting.Domain.Interfaces.Services;
using Posting.Domain.Models;

namespace Posting.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> CreatePost(Post request, CancellationToken cancellationToken)
        {
            return await _postRepository.CreatePost(request, cancellationToken);
        }

        public async Task<IEnumerable<FeedItem>> GetLatestFeed(int take, int skip)
        {
            var response = await _postRepository.GetLatestFeed(take, skip);
            return response;
        }

        public async Task<Post?> GetPostById(int postId)
        {
            return await _postRepository.GetPostById(postId);
        }

        public async Task<IEnumerable<Post>?> GetPostsByUserId(int userId)
        {
            return await _postRepository.GetPostsByUserId(userId);
        }

        public async Task<bool> UpdatePost(Post post, CancellationToken cancellationToken)
        {
            return await _postRepository.UpdatePost(post, cancellationToken);
        }
    }
}
