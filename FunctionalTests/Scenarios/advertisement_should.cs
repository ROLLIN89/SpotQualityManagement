using FunctionalTests.Config;
using Idealista.Domain.Services;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTests.Scenarios
{
    public class advertisement_should : TestBase
    {
        IAdvertisementService advertisementService;

        public advertisement_should()
        {
            base.SetUp();
        }

        public override void SetData()
        {
            //advertisementService = ServiceProvider.GetService<IAdvertisementService>();
            Assert.NotNull(advertisementService);
        }
    }
}
