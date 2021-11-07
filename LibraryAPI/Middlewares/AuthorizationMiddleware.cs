using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Middlewares
{
    /// <summary>
    /// 2.2.4 - Миддлевейр авторизации
    /// </summary>
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers["Authorization"] != "Basic admin:admin")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("You aren't authorized" + " " + context.Request.Headers["Authorization"]);
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
