using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corporate.Back.Copa.Api.Business.Contracts;
using Corporate.Back.Copa.Api.Business.Services;
using Corporate.Back.Copa.Api.Client.Commom;
using Corporate.Back.Copa.Core.Contracts;
using Corporate.Back.Copa.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Corporate.Back.Copa.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var settings = Configuration.GetSection(ApplicationOptions.Property);
            ApplicationOptions options = settings.Get<ApplicationOptions>();
            services.Configure<ApplicationOptions>(settings);
            services.AddHttpClient(options.HttpConfig, c =>
            {
                c.BaseAddress = new Uri(options.BaseAddress);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddCors();

            services.AddHttpClient();
            services.AddScoped<ITeamsCupClientService, TeamsCupClientService>();
            services.AddTransient<ITeamsCupBusinessService, TeamsCupBusinessService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

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
