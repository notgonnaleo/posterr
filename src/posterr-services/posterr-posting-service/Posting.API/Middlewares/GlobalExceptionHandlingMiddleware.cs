using Posting.Domain.Records;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Posting.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ExceptionResponse response;
            switch (ex)
            {
                case ApplicationException appEx:
                    response = new ExceptionResponse(
                        HttpStatusCode.BadRequest,
                        string.IsNullOrWhiteSpace(appEx.Message) ? "Something went wrong, please try again later." : appEx.Message
                    );
                    break;

                case KeyNotFoundException keyEx:
                    response = new ExceptionResponse(
                        HttpStatusCode.NotFound,
                        string.IsNullOrWhiteSpace(keyEx.Message) ? "The item you're looking for does not exist." : keyEx.Message
                    );
                    break;

                case DbUpdateException dbEx:
                    // I don't wanna show to the user my DB structure so save the real issue at our whatever log storage
                    // and then show a friendly error message.
                    _logger.LogError(dbEx, "Database error occurred: {Message}", dbEx.InnerException?.Message ?? dbEx.Message);

                    response = new ExceptionResponse(
                        HttpStatusCode.InternalServerError,
                        "A database error occurred while processing your request. Please try again later."
                    );
                    break;

                default:
                    _logger.LogError(ex, "An unexpected error occurred: {Message}", ex.Message);

                    response = new ExceptionResponse(
                        HttpStatusCode.InternalServerError,
                        string.IsNullOrWhiteSpace(ex.Message) ? "Unexpected error happened, please try again later." : ex.Message
                    );
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
