using FluentAssertions;
using Idealista.Domain.Services;
using Idealista.Seedwork.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using UnitTest.Config;
using Xunit;

namespace UnitTest.Domain.Services
{
    public class advertisement_service_should : TestBase
    {
        IAdvertisementService advertisementService;
        InMemoryPersistence data;

        public advertisement_service_should()
        {
            base.SetUp();
        }

        public override void SetData()
        {
            advertisementService = ServiceProvider.GetService<IAdvertisementService>();
            Assert.NotNull(advertisementService);

            data = ServiceProvider.GetService<InMemoryPersistence>();
            Assert.NotNull(data);
        }


        [Fact]
        public void calculate_score_with_success()
        {
            var advertisement = data.GetAdversisementById(2);
            var oldScore = advertisement.Score;

            advertisementService.CalculateScore(advertisement.Id);

            advertisement.Score.Should().NotBe(0);
            oldScore.Should().NotBe(advertisement.Score);
        }

        [Fact]
        public void calculate_wrong_score()
        {
            advertisementService.CalculateScore(20);

            var advertisement = data.GetAdversisementById(20);
            advertisement.Should().BeNull();
        }
    }
}
