using Posting.Domain.Entities;
using Posting.Infrastructure.Contexts;
using Posting.Domain.Interfaces.Repositories;
using System.Data;
using Dapper;
using Posting.Domain.Models;
using Posting.Infrastructure.SqlQueries;

namespace Posting.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;
        private readonly IDbConnection _connection;
        public PostRepository(AppDbContext context, IDbConnection dbConnection)
        {
            _context = context;
            _connection = dbConnection;
        }

        public async Task<IEnumerable<PostThumbnail>> GetLatestPosts(int take, int skip)
        {
            // Just a heads up, we are not passing the cancellation token here for two reasons.
            // 1. It's not really necessary since this is just a query and not a actual command with update or insert actions
            // 2. Dapper doesn't have support to cancellation token for QueryAsync method. We could do it using ExecuteAsync or 
            // any other alternative, but as mentioned before, it's not worth the headache since it's not a high-concern logic method.
            var sql = new GetLatestPostsQuery(take, skip);
            var response = await _connection.QueryAsync<PostThumbnail>(sql.Query, sql.Parameters);
            return response;
        }

        public async Task<bool> CreatePost(Post request, CancellationToken cancellationToken)
        {
            var response = await _context.Posts.AddAsync(request);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
