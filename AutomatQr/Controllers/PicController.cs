using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace AutomatQr.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PicController : ControllerBase
    {
        private readonly IHostingEnvironment _env;

        public PicController(IHostingEnvironment env)
        {
            this._env = env;
        }

        // GET pic/id
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return File(Helper.Helper.GetQr(id, _env.WebRootFileProvider.GetFileInfo("Thai_QR_Payment_Logo-03.png")?.PhysicalPath), "image/png");
        }
    }
}