using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Common.AspNetCore.Middleware
{
    public static class ApiCustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiCustomExceptionHandlerMiddleware>();
        }
    }
}