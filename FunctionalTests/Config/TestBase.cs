using Idealista.Domain.Services;
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
            services.AddTransient<IAdvertisementService, AdvertisementService>();
            ServiceProvider = services.BuildServiceProvider();
            //Init data test
            SetData();
        }

        public abstract void SetData();
    }
}
