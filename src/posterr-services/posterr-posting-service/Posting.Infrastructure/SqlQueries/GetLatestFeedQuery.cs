namespace Posting.Infrastructure.SqlQueries
{
    public class GetLatestFeedQuery : ISqlQueryTemplate
    {
        public GetLatestFeedQuery(int take, int skip)
        {
            Parameters = new
            {
                Take = take,
                Skip = skip
            };

            Query = @"
            SELECT 
                p.""PostId"", 
                p.""PostContent"", 
                p.""TotalReposts"", 
                p.""DateCreated"", 
                p.""UserId"" AS ""PostUserId"", 
                u.""Username"" AS ""PostUsername"", 
                CASE WHEN r.""RepostId"" IS NULL THEN 0 ELSE 1 END AS ""IsRepost"",
                r.""RepostId"", 
                r.""RepostUserId"", 
                ru.""Username"" AS ""RepostUsername"", 
                r.""RepostDate""
            FROM 
                ""Posts"" p
                JOIN ""Users"" u 
                    ON u.""UserId"" = p.""UserId"" 
                FULL OUTER JOIN ""Reposts"" r
                    ON r.""ParentPostId"" = p.""PostId""
                LEFT JOIN ""Users"" ru 
                    ON ru.""UserId"" = r.""RepostUserId""
            ORDER BY 
                p.""PostId"" DESC,
                r.""RepostId"" DESC;
            "; 
        }

        public string Query { get; }
        public object Parameters { get; }
    }
}
