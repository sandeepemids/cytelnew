using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;


namespace DataAugmentation.Api.Extensions
{
    /// <summary>
    /// Extension class defined for Service Class
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures CORS Policy
        /// </summary>
        /// <param name="services">Services Object</param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        /// <summary>
        /// Configures API Versioning
        /// </summary>
        /// <param name="services">Services Object</param>
        public static void ConfigureApiVersioning(this IServiceCollection services)
        {
            //services.AddApiVersioning(o =>
            //{
            //    o.ReportApiVersions = true;
            //    o.AssumeDefaultVersionWhenUnspecified = true;
            //    o.DefaultApiVersion = new ApiVersion(1, 0);
            //});
        }
    }
}
