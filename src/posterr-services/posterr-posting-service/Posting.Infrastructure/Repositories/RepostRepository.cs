using Dapper;
using Posting.Domain.Entities;
using Posting.Domain.Interfaces.Repositories;
using Posting.Domain.Models;
using Posting.Infrastructure.Contexts;
using Posting.Infrastructure.SqlQueries;
using System.Data;

namespace Posting.Infrastructure.Repositories
{
    public class RepostRepository : IRepostRepository
    {
        private readonly AppDbContext _context;
        private readonly IDbConnection _connection;
        public RepostRepository(AppDbContext appDbContext, IDbConnection dbConnection)
        {
            _context = appDbContext;
            _connection = dbConnection;
        }

        public async Task<bool> CreateRepost(Repost request, CancellationToken cancellationToken)
        {
            _context.Reposts.Add(request);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<IEnumerable<RepostThumbnail>> GetLatestReposts(int take, int skip)
        {
            var sql = new GetLatestRepostsQuery(take, skip);
            var response = await _connection.QueryAsync<RepostThumbnail>(sql.Query, sql.Parameters);
            return response;
        }
    }
}
