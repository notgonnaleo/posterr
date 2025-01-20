using MediatR;
using Posting.Domain.Commands.Requests;
using Posting.Domain.Entities;
using Posting.Domain.Interfaces.Repositories;

namespace Posting.Infrastructure.Handlers.Posts
{
    public class PublishNewPostHandler : IRequestHandler<CreatePostRequest, bool>
    {
        private readonly IPostRepository _postRepository;
        public PublishNewPostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.PostContent))
            {
                throw new ArgumentException("You cannot publish an empty post");
            }

            var authorPosts = await _postRepository.GetPostsByUserId(request.AuthorId);
            if(authorPosts is not null) 
            {
                var latestPosts = authorPosts.Where(x => x.DateCreated.Day == DateTime.UtcNow.Day);
                if (latestPosts.Count() > 5)
                {
                    throw new Exception("You cannot publish more posts than you already have (5 posts per day)");
                }
            }

            // NOTE: Usually on international SaaS, we can treat dates as UTC and then
            // we would get the offset from another service (something like an user profile service) 
            // by making him insert his location somewhere so we could convert it on the server-side
            // OR we could also get the browser date and re-calculate the timezone offset.
            // I prefer the server-side approach, due having more features and reliability here
            // but we still have both options to work with.
            return await _postRepository.CreatePost(new Post()
            {
                UserId = request.AuthorId,
                PostContent = request.PostContent,
                TotalReposts = 0,
                DateCreated = DateTime.UtcNow
            }, cancellationToken);
        }
    }
}
