using coding_test_ranking.infrastructure.api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace coding_test_ranking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<QualityAdvertisement>> GetAllAdvertisementsForQuality()
        {
            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Advertisement>> GetAllAdvertisements()
        {
            return NotFound();
        }

        [HttpGet]
        [Route("calculate-score")]
        [Authorize(Policy = Policies.Catalog.Read)]
        [ProducesResponseType(typeof(ProductMasterTagsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalculateScore()
        {
            return Ok();
        }
    }
}
