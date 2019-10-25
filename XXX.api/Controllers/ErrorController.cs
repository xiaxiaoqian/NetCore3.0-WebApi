using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace XXX.api.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult Get()
        {
            Models.RetModel r = new Models.RetModel();
            r.code = 0;
            r.message = "接口开小差了";

            return Ok(r);
        }
    }
}