using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using Walpy.VacancyApp.Server.Models.Responses;

namespace Walpy.VacancyApp.Server.Middleware
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
                if (!IsApiPath(context))
                {
                    return;
                }

                var statusCode = context.Response.StatusCode;
                if (statusCode == 400
                    || statusCode == 404
                    || statusCode == 409)
                {
                    WriteApiResponse(context).Wait();
                }
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
            if (!IsApiPath(context))
            {
                return false;
            }


            var response = new ErrorResponse
            {
                Message = exception.Message,
                Source = exception.Source,
                Code = exception.HResult
            };
            context.Response.StatusCode = 500;
            WriteApiResponse(context, response).Wait();
            return true;
        }

        private static bool IsApiPath(HttpContext context)
            => context.Request.Path.StartsWithSegments(new PathString("/api"));

        private static Task WriteApiResponse(HttpContext context, object data = null)
        {
            var response = data == null ? String.Empty : JsonConvert.SerializeObject(data);
            return context.Response.WriteAsync(response);
        }
    }
}