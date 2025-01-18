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

        public async Task<IEnumerable<PostThumbnail>> GetLatestPosts(int take, int skip)
        {
            take = take <= 0 ? 0 : take;
            skip = skip <= 0 ? 0 : skip;
            var response = await _postRepository.GetLatestPosts(take, skip);
            return response;
        }
    }
}
