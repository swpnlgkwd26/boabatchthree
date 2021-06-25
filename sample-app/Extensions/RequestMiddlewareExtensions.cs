using Microsoft.AspNetCore.Builder;
using sample_app.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Extensions
{
    // Extension Method :
    // string.class doenst have Reverse method .So wwe can add it through
    // extension methods
    // it should be class and Static methods
    public static class RequestMiddlewareExtensions
    {
        // Whenever some calls UseReuqest Culture 
        // He should call Request Culture Middleware
        public static IApplicationBuilder UseRequestCulture
            (this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCultureMiddleware>();
        }
    }
}
