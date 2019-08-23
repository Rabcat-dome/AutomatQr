using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutomatQr.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        // GET health
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(new { description="API OK MQTT connected", status = "UP" });
        }
    }
}
