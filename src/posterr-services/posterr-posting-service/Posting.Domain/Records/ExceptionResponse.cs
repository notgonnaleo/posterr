using System.Net;

namespace Posting.Domain.Records
{
    // I want the exception model be a record because it should be immutable, 
    // the ONLY reason for the existence of this item is to TRANSFER DATA (DTO Concept)
    // so it must make the data come the most accurate possible since it's the only responsability of it.
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
