using Idealista.Domain.Queries.Advertisements;
using Idealista.Domain.Services;
using Idealista.Infrastructure.Queries.Advertisements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using MediatR;
using Hellang.Middleware.ProblemDetails;
using Idealista.Seedwork.Infrastructure.Data;
using Idealista.Application.Advertisements;

namespace Idealista.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(AdvertisementCommandHandler).Assembly);

            services.AddTransient<IAdvertisementService, AdvertisementService>();
            services.AddTransient<IAdvertisementsQuery, AdvertisementsQuery>();
            services.AddSingleton<InMemoryPersistence>();
            services.AddProblemDetails();
            services.AddSwaggerGen();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseProblemDetails();
            app.UseSwagger();
            app.UseSwaggerUI(s => 
            {
                s.SwaggerEndpoint("v1/swagger.json", "Idealista Ranking");
                s.RoutePrefix = "swagger";
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
