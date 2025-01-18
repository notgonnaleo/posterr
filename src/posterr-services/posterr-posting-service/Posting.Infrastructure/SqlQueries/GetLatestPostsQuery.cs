namespace Posting.Infrastructure.SqlQueries
{
    public class GetLatestPostsQuery : ISqlQueryTemplate
    {
        /// <summary>
        /// <para>Query from the database the latest posts created ordered by descending post ids,</para>
        /// <para>this way we are going to always get the most recent posts created.</para>
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        public GetLatestPostsQuery(int take, int skip)
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
                    u.""UserId"",
                    u.""Username"" 
                FROM 
                    ""Posts"" p
                    JOIN ""Users"" u 
                        ON u.""UserId"" = p.""UserId"" 
                ORDER BY 
                   p.""PostId"" 
                DESC
                OFFSET @Skip ROWS
                FETCH NEXT @Take ROWS ONLY
            ";
        }

        public string Query { get; }
        public object Parameters { get; }
    }
}
