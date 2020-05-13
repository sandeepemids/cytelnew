using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Simulation.Api.Constants;
using Simulation.Models;
using System.Net;

namespace Simulation.Api.Extensions
{
    /// <summary>
    /// Middleware definition for Global Exception Handler
    /// </summary>
    public static class ExceptionMiddleware
    {
        /// <summary>
        /// Configures Exception Handler
        /// </summary>
        /// <param name="app">Application Builder Object</param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = ExceptionMessageCodes.INTERNAL_SERVER_ERROR
                        }.ToString());
                    }
                });
            });
        }
    }
}
