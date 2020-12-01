using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coding_test_ranking.infrastructure.api;
using Microsoft.AspNetCore.Mvc;

namespace coding_test_ranking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<QualityAd>> qualityListing()
        {
            return NotFound();
        }
        [HttpGet]
        public ActionResult<IEnumerable<PublicAd>> publicListing()
        {
            return NotFound();
        }

        [HttpGet]
        public ActionResult calculateScore()
        {
            return NotFound();
        }
    }
}
