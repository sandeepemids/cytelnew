using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ProjectManager.Constants;

namespace ProjectManager.Api.Extensions
{
    /// <summary>
    /// Extension Method for Swagger implementation
    /// </summary>
    public static class SwaggerExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = SwaggerMessages.API_VERSION,
                    Title = SwaggerMessages.TITLE,
                    Description = SwaggerMessages.TITLE,
                    Contact = new OpenApiContact() { Name = SwaggerMessages.CONTACT_NAME }
                });
            });

        }
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerMessages.V1_JSON_URL, SwaggerMessages.API_NAME);
            });

        }
    }
}
