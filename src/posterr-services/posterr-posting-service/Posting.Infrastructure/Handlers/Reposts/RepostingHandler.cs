using MediatR;
using Posting.Domain.Commands.Requests;
using Posting.Domain.Entities;
using Posting.Domain.Interfaces.Repositories;
using Posting.Domain.Models;
using Posting.Domain.Queries.Requests;

namespace Posting.Infrastructure.Handlers.Reposts
{
    public class RepostingHandler : IRequestHandler<RepostRequest, RepostResponse>
    {
        private readonly IRepostRepository _repostRepository;
        private readonly IPostRepository _postRepository;


        public RepostingHandler(IRepostRepository repostRepository, IPostRepository postRepository)
        {
            _repostRepository = repostRepository;
            _postRepository = postRepository;
        }

        public async Task<RepostResponse> Handle(RepostRequest request, CancellationToken cancellationToken)
        {
            if(request.PostId == 0)
            {
                throw new KeyNotFoundException("You cannot repost something that doesn't exist.");
            }

            int? repostLogId = null; 
            bool Reposted = false;

            var post = await _postRepository.GetPostById(request.PostId);            
            if(post is null)
            {
                throw new KeyNotFoundException("The post you're trying to repost does not exist or is deleted.");
            }
            
            if(post.UserId == request.UserId)
            {
                throw new Exception("You cannot repost your own posts.");
            }

            // I did implement a un-redo repost logic but it's not going to be used on this 
            // case, but if we wanted to do so, just remove the hard-coded true from line 47
            if (request.IsReposting && true) // Save the repost action on database
            {
                post.TotalReposts++;
                repostLogId = await _repostRepository.CreateRepost(new Repost()
                {
                    ParentPostId = request.PostId,
                    RepostUserId = request.UserId,
                    RepostDate = DateTime.UtcNow,
                }, cancellationToken);
                Reposted = true;
            }
            else 
            // Undo the repost logic and we will only do that
            // in case the post total repost amount is more than zero
            // since we can't un-repost something that was never reposted before.
            {
                if (post.TotalReposts > 0)
                {
                    post.TotalReposts--;
                    await _postRepository.UpdatePost(post, cancellationToken);
                }
                Reposted = false;
            }

            return new RepostResponse()
            {
                PostId = post.PostId, // I'd rather use the database result instead the execution-time parameter for this case.
                RepostId = repostLogId,
                Reposted = Reposted,
            };
        }
    }
}
