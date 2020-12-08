using Idealista.Domain.Queries.Advertisements;
using Idealista.Domain.Queries.Advertisements.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Idealista.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly IAdvertisementsQuery query;
        //private readonly IMapper mapper;

        public AdvertisementsController(IAdvertisementsQuery query)
            //IMapper mapper)
        {
            this.query = query;
            //this.mapper = mapper;
        }

        [HttpGet]
        [Route("all/quality")]
        //[Authorize(Policy = Policies.ProductsCatalog.Read)]
        [ProducesResponseType(typeof(IEnumerable<QualityAdvertisementResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllAdvertisementsForQuality()
        {
            var results = query.GetAllForQuality();
            return Ok(results);
        }

        [HttpGet]
        [Route("all")]
        //[Authorize(Policy = Policies.ProductsCatalog.Read)]
        [ProducesResponseType(typeof(IEnumerable<AdvertisementResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllAdvertisements()
        {
            var results = query.GetAll();
            return Ok(results);
        }

        [HttpGet]
        [Route("calculate-score")]
        //[Authorize(Policy = Policies.Catalog.Read)]
        //[ProducesResponseType(typeof(ProductMasterTagsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalculateScore()
        {
            return Ok();
        }
    }
}
