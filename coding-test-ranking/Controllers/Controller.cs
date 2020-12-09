using Idealista.Application.Advertisements;
using Idealista.Domain.Queries.Advertisements;
using Idealista.Domain.Queries.Advertisements.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idealista.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IAdvertisementsQuery query;

        public AdvertisementsController(IMediator mediator, IAdvertisementsQuery query)
        {
            this.mediator = mediator;
            this.query = query;
        }

        [HttpGet]
        [Route("irrelevantForQuality")]
        [ProducesResponseType(typeof(IEnumerable<QualityAdvertisementResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllIrrelevantAdvertisementsForQuality()
        {
            var results = query.GetAllIrrelevant();
            return Ok(results);
        }

        [HttpGet]
        [Route("relevantForUsers")]
        [ProducesResponseType(typeof(IEnumerable<AdvertisementResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllRelevantAdvertisements()
        {
            var results = query.GetAllRelevant();
            return Ok(results);
        }

        [HttpPost]
        [Route("calculate-score")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalculateScore(int advertisementId)
        {
            var command = new AdvertisementCommand { Id = advertisementId};
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
