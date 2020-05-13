using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectManager.Api.Extensions;
using ProjectManager.Constants;
using ProjectManager.Models;
using ProjectManager.Service;
using ProjectManager.Service.Interfaces;

namespace ProjectManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApiVersioning();
            services.ConfigureCors();
            services.AddControllers();
            services.AddSwagger();
            services.AddMvc().AddNewtonsoftJson();
            services.Configure<ProjectManagerSettings>(Configuration.GetSection("ProjectManagerSettings"));
            services.AddSingleton<IProjectService, ProjectService>();
            services.AddSingleton<IInputAdvisorService, InputAdvisorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCustomSwagger();
            }

            app.UseCors(ServiceConstants.CORS_POLICY);
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
