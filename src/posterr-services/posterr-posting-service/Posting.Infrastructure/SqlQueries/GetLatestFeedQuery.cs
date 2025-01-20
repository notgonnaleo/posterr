namespace Posting.Infrastructure.SqlQueries
{
    public class GetLatestFeedQuery : ISqlQueryTemplate
    {
        /// <summary>
        /// <para>Get all the recent reposts of a parent posting,</para>
        /// <para>We are always linking the intermediary repost to the original post.</para>
        /// <para>So in this way, all new reposts actions go direct to the parent/original post.</para>
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
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
                    originalAuthor.""UserId"" AS ""AuthorId"",
                    originalAuthor.""Username"" AS ""AuthorName"",
                    r.""RepostId"",
                    r.""RepostUserId"" AS ""RepostUserId"",
                    repostAuthor.""Username"" AS ""RepostUsername"",
                    r.""RepostDate"",
                    COUNT(*) OVER() AS ""TotalRowCount""
                FROM 
                    ""Posts"" p
                JOIN ""Users"" originalAuthor 
                    ON originalAuthor.""UserId"" = p.""UserId""

                LEFT JOIN ""Reposts"" r
                    ON r.""ParentPostId"" = p.""PostId""
                JOIN ""Users"" repostAuthor 
                    ON repostAuthor.""UserId"" = r.""RepostUserId""
                ORDER BY 
                    r.""RepostDate""
                DESC
                OFFSET @Skip ROWS
                FETCH NEXT @Take ROWS ONLY
            ";
        }

        public string Query { get; }
        public object Parameters { get; }
    }
}
