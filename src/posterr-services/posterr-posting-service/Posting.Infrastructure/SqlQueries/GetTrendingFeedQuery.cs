namespace Posting.Infrastructure.SqlQueries
{
    public class GetTrendingFeedQuery : ISqlQueryTemplate
    {
        public GetTrendingFeedQuery(int take, int skip)
        {
            Parameters = new
            {
                Take = take,
                Skip = skip
            };

            Query = @"
            SELECT 
                p.""PostId""
                ,p.""PostContent""
                ,p.""TotalReposts""
                ,p.""DateCreated""
                ,p.""PostId"" AS ""PostUserId""
                ,u.""Username""
            FROM ""Posts"" p
            JOIN ""Users"" u ON p.""UserId"" = u.""UserId""
            ORDER BY p.""TotalReposts"" DESC
            LIMIT @Take OFFSET @Skip;
            "; 
        }

        public string Query { get; }
        public object Parameters { get; }
    }
}
