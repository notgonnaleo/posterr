using Posting.Domain.Entities;
using Posting.Infrastructure.Contexts;
using Posting.Domain.Interfaces.Repositories;
using System.Data;
using Dapper;
using Posting.Domain.Models;
using Posting.Infrastructure.SqlQueries;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Post?> GetPostById(int postId)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.PostId == postId);
        }

        public async Task<IEnumerable<FeedItem>> GetLatestFeed(int take, int skip)
        {
            var sql = new GetLatestFeedQuery(take, skip);
            var response = await _connection.QueryAsync<FeedItem>(sql.Query, sql.Parameters);
            return response;
        }

        public async Task<IEnumerable<FeedItem>> GetTrendingFeed(int take, int skip)
        {
            var sql = new GetTrendingFeedQuery(take, skip);
            var response = await _connection.QueryAsync<FeedItem>(sql.Query, sql.Parameters);
            return response;
        }

        public async Task<bool> CreatePost(Post request, CancellationToken cancellationToken)
        {
            var response = await _context.Posts.AddAsync(request);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdatePost(Post post, CancellationToken cancellationToken)
        {
            _context.Posts.Update(post);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<IEnumerable<Post>?> GetPostsByUserId(int userId)
        {
           return await _context.Posts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<FeedItem>> GetByKeyword(string keyword)
        {
            var sql = new GetByKeyword(keyword);
            var response = await _connection.QueryAsync<FeedItem>(sql.Query, sql.Parameters);
            return response;
        }
    }
}
