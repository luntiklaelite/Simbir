using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Middlewares
{
    /// <summary>
    /// 2.2.3 - Миддлвейр, подсчитывающий время выполнения запроса
    /// </summary>
    public class RequestTimeLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestTimeLoggerMiddleware(RequestDelegate next, ILogger<RequestTimeLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            DateTimeOffset dtStart = DateTimeOffset.Now;
            try
            {
                await _next.Invoke(context);
            }
            finally
            {
                DateTimeOffset dtEnd = DateTimeOffset.Now;
                _logger.LogInformation($"Request Time: START [{dtStart.ToString("HH:mm:ss:fffffff")}] | END [{dtEnd.ToString("HH:mm:ss:fffffff")}] | Elapsed [{dtEnd - dtStart}]");
            }
        }
    }
}