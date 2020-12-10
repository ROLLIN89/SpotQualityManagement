using Idealista.Seedwork.Infrastructure.Data;
using UnitTest.Config;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Idealista.Domain.Queries.Advertisements;
using System.Linq;
using FluentAssertions;

namespace UnitTest.Infrastructure.Queries
{
    public class advertisement_queries_should : TestBase
    {
        IAdvertisementsQuery advertisementQuery;
        InMemoryPersistence data;

        public advertisement_queries_should()
        {
            base.SetUp();
        }

        public override void SetData()
        {
            advertisementQuery = ServiceProvider.GetService<IAdvertisementsQuery>();
            Assert.NotNull(advertisementQuery);

            data = ServiceProvider.GetService<InMemoryPersistence>();
            Assert.NotNull(data);
        }


        [Fact]
        public void get_all_irrelevant_advertisement_with_success()
        {
            var irrelevantAdvertisements = advertisementQuery.GetAllIrrelevant();

            irrelevantAdvertisements.Count().Should().Be(0);
        }

        [Fact]
        public void get_all_relevant_advertisement_with_success()
        {
            var irrelevantAdvertisements = advertisementQuery.GetAllRelevant();

            irrelevantAdvertisements.Count().Should().Be(data.GetAllAdvertisements().Count());
        }
    }
}
