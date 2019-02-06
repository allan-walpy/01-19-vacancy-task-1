using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using App.Server.Models.Responses;

namespace App.Server.Middleware
{
    public class ApiErrorHandlingMiddleware
    {
        private RequestDelegate Next { get; }
        private ILogger<ApiErrorHandlingMiddleware> Logger { get; }

        public ApiErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            Next = next;
            Logger = loggerFactory.CreateLogger<ApiErrorHandlingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception error)
            {
                Logger.LogError(error, "Server Error Occured");
                bool isHandled = HandleError(context, error);
                if (!isHandled)
                {
                    throw;
                }
            }
        }

        private static bool HandleError(HttpContext context, Exception exception)
        {
            if (!IsApiException(context))
            {
                return false;
            }

            WriteApiResponse(context, exception).Wait();
            return true;
        }

        private static bool IsApiException(HttpContext context)
            => context.Request.Path.StartsWithSegments(new PathString("/api"));

        private static Task WriteApiResponse(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 500;
            var response = JsonConvert.SerializeObject(
                new ErrorResponse
                {
                    Message = exception.Message,
                    Source = exception.Source,
                    Code = exception.HResult
                });

            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(response);
        }
    }
}