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

        public async Task<IEnumerable<PostThumbnail>> GetLatestPosts(int take, int skip)
        {
            take = take <= 0 ? 0 : take;
            skip = skip <= 0 ? 0 : skip;
            var response = await _postRepository.GetLatestPosts(take, skip);
            return response;
        }

        public async Task<Post?> GetPostById(int postId)
        {
            return await _postRepository.GetPostById(postId);
        }

        public async Task<IEnumerable<PostThumbnail>> GetPostThumbnails(int take, int skip)
        {
            take = take <= 0 ? 0 : take;
            skip = skip <= 0 ? 0 : skip;
            var response = await _postRepository.GetPostThumbnails(take, skip);
            return response;
        }

        public async Task<bool> UpdatePost(Post post, CancellationToken cancellationToken)
        {
            return await _postRepository.UpdatePost(post, cancellationToken);
        }
    }
}
