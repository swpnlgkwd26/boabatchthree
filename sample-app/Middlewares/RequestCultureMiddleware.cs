using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Middlewares
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;
        // RequestDelegate Calls Next Middleware
        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Read QueryString and Set the Curlture as per the Querystring passed
        // InvokeAsync is automatically called
        public async Task InvokeAsync(HttpContext context)
        {
            // Read QueryString
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                // Set the Culture
                var culture = new CultureInfo(cultureQuery);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            await _next(context); // Call next Middleware
        }
    }
}
