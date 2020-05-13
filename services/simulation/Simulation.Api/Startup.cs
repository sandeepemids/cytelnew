using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simulation.Api.Extensions;
using Simulation.Models;
using SimulationModel.Service;
using SimulationModel.Service.Interfaces;
using Simulation.Service;
using Simulation.Service.Interfaces;

namespace Simulation.Api
{
    /// <summary>
    /// Startup Class Definition
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor for Startup Class
        /// </summary>
        /// <param name="configuration">Configuration Object</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration Parameter Settings
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configurs various services
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services">Services Object</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApiVersioning();
            services.ConfigureCors();
            services.AddControllers();
            services.AddSwagger();
            services.Configure<SimulationSettings>(Configuration.GetSection("SimulationSettings"));
            services.AddSingleton<ISimulationService, SimulationService>();
            services.AddSingleton<ISimulationModelService, SimulationModelService>();
            services.AddSingleton<IEngine, FixedSampleEngine>();
        }

        /// <summary>
        /// Configures App and Environment
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app">An Application Builder</param>
        /// <param name="env">Environment Variable</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCustomSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
