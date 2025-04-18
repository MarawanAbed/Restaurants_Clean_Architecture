﻿
using System.Diagnostics;

namespace Restaurants.API.Middlewares
{
    public class ReqestTimeLoggingMiddleware(ILogger<ReqestTimeLoggingMiddleware> logger) : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopWatch = Stopwatch.StartNew();
            await next(context);
            stopWatch.Stop();

            if (stopWatch.ElapsedMilliseconds / 1000 > 4)
            {
                logger.LogInformation("Request [{Verb}] at {Path} took {Time} ms", context.Request.Method, context.Request.Path, stopWatch.ElapsedMilliseconds);
            }
        }
    }
}
