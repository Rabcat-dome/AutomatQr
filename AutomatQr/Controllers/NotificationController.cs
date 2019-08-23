using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace AutomatQr.Controllers
{
    [Route("push/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        // GET push/notification
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hello", "World" };
        }

        // GET api/notification/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/notification
        [HttpPost]
        public JsonResult Post([FromBody] string value)
        {
            return new JsonResult(new {});
        }

    }

}
