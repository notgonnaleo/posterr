namespace Posting.Infrastructure.SqlQueries
{
    public interface ISqlQueryTemplate
    {
        public string Query { get; }
        public object Parameters { get; }
    }
}
