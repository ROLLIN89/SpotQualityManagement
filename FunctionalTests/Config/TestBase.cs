using AutoMapper;
using Idealista.Application.Advertisements;
using Idealista.Domain.Queries.Advertisements;
using Idealista.Infrastructure.Queries.Advertisements;
using Idealista.Seedwork.Infrastructure.Data;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FunctionalTests.Config
{
    public abstract class TestBase
    {
        protected IServiceCollection services = new ServiceCollection();
        protected IServiceProvider ServiceProvider;
        public virtual void SetUp()
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-es");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;

            services.AddTransient<IAdvertisementsQuery, AdvertisementsQuery>();
            services.AddSingleton<InMemoryPersistence>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(AdvertisementCommandHandler).Assembly);

            ServiceProvider = services.BuildServiceProvider();
            //Init data test
            SetData();
        }

        public abstract void SetData();
    }
}
