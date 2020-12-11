using FluentAssertions;
using FunctionalTests.Config;
using Idealista.Api.Controllers;
using Idealista.Application.Advertisements;
using Idealista.Domain.Queries.Advertisements;
using Idealista.Domain.Queries.Advertisements.Responses;
using Idealista.Seedwork.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Xunit;

namespace FunctionalTests.Scenarios
{
    public class advertisement_should : TestBase
    {
        IMediator mediatR;
        IAdvertisementsQuery advertisementQuery;
        AdvertisementsController controller;
        InMemoryPersistence data;

        public advertisement_should()
        {
            base.SetUp();
        }

        public override void SetData()
        {
            advertisementQuery = ServiceProvider.GetService<IAdvertisementsQuery>();
            Assert.NotNull(advertisementQuery);

            mediatR = ServiceProvider.GetService<IMediator>();
            Assert.NotNull(mediatR);

            controller = new AdvertisementsController(mediatR, advertisementQuery);
            Assert.NotNull(controller);

            data = ServiceProvider.GetService<InMemoryPersistence>();
            Assert.NotNull(data);
        }


        [Fact]
        public void get_all_irrelevant_advertisement_for_quality_with_success()
        {
            var response = controller.GetAllIrrelevantAdvertisementsForQuality();

            Assert.IsType<OkObjectResult>(response);
            var objectResponse = response as ObjectResult;
            objectResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public void get_all_irrelevant_advertisement_for_quality_with_two_irrelevant_advertisement()
        {
            var advertisement = data.GetAdversisementById(2);
            advertisement.SetIrrelevantSince(DateTime.Now);

            var advertisement2 = data.GetAdversisementById(3);
            advertisement2.SetIrrelevantSince(DateTime.Now.AddDays(-1));

            var response = controller.GetAllIrrelevantAdvertisementsForQuality();

            Assert.IsType<OkObjectResult>(response);
            var objectResponse = response as ObjectResult;
            objectResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var advertisements = objectResponse.Value as List<QualityAdvertisementResponse>;
            advertisements.Count().Should().Be(2);
        }

        [Fact]
        public void get_all_relevant_advertisement_with_success()
        {
            var response = controller.GetAllRelevantAdvertisements();

            Assert.IsType<OkObjectResult>(response);
            var objectResponse = response as ObjectResult;
            objectResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var advertisements = objectResponse.Value as List<AdvertisementResponse>;
            advertisements.Count().Should().Be(8);
        }

        [Fact]
        public void get_all_relevant_advertisement_without_one_irrelevant_advertisement()
        {
            var advertisement = data.GetAdversisementById(2);
            advertisement.SetIrrelevantSince(DateTime.Now);

            var allAdvertisements = data.GetAllAdvertisements();

            var response = controller.GetAllRelevantAdvertisements();

            Assert.IsType<OkObjectResult>(response);
            var objectResponse = response as ObjectResult;
            objectResponse.StatusCode.Should().Be((int)HttpStatusCode.OK);

            var advertisements = objectResponse.Value as List<AdvertisementResponse>;
            advertisements.Count().Should().Be(7);
            advertisements.Count().Should().NotBe(allAdvertisements.Count());
        }

        [Fact]
        public void calculate_score_with_success()
        {
            var mediatorMock = new Mock<IMediator>();

            mediatorMock
                .Setup(m => m.Send(It.IsAny<AdvertisementCommandHandler>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Unit());

            var controllerWithMediatRMocked = new AdvertisementsController(mediatorMock.Object, advertisementQuery);

            var response = controllerWithMediatRMocked.CalculateScore(1);

            Assert.IsType<OkObjectResult>(response.Result);
        }
    }
}
