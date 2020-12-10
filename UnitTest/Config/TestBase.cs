using AutoMapper;
using Idealista.Domain.Queries.Advertisements;
using Idealista.Domain.Services;
using Idealista.Infrastructure.Queries.Advertisements;
using Idealista.Seedwork.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace UnitTest.Config
{
    public abstract class TestBase
    {
        protected IServiceCollection services = new ServiceCollection();
        protected IServiceProvider ServiceProvider;
        public virtual void SetUp()
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-es");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            services.AddTransient<IAdvertisementService, AdvertisementService>();
            services.AddTransient<IAdvertisementsQuery, AdvertisementsQuery>();
            services.AddSingleton<InMemoryPersistence>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            ServiceProvider = services.BuildServiceProvider();
            //Init data test
            SetData();
        }

        public abstract void SetData();
    }
}
