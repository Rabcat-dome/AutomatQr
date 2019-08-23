using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutomatQr.Helper;
using Microsoft.AspNetCore.Hosting;
using QRCoder;

namespace AutomatQr.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class GenQrController : ControllerBase
    {
        private readonly Notifier _line;
        private readonly IHostingEnvironment _env;

        public GenQrController(IHostingEnvironment env)
        {
            this._env = env;
            _line = new Notifier("HIQIwipZomTRhYwVy0N3SMxYWtCwXYqI0krIflf9z0w");
        }

        [HttpGet("{machine?}/{product?}/{amount?}/{price?}")]
        public async Task<IActionResult> Get(string machine = "P10D41M001S00001", string product = "L0001T001N0001",string amount="Q001", string price = "100")
        {
            var tag00 = "000201";
            var tag01 = "010212";
            var tag30 = "30" + (16 + 16 + 15 + machine.Length + (product+amount).Length);
            tag30 += "00" + "16" + "A000000677010112";
            tag30 += "01" + "15" + "010556209616101";
            tag30 += "02" + machine.Length + machine;
            tag30 += "03" + (product+amount).Length + product+amount;
            var tag53 = "53" + "03" + "764";
            var tag54 = "54" + price.Length + price;
            var tag58 = "58" + "02" + "TH";
            var tag63 = "63" + "04";

            var tag = tag00 + tag01 + tag30 + tag53 + tag54 + tag58+tag63;
            tag += Helper.Helper.CalcCrc16(tag);

            try
            {
                await _line.Notify($"\nตู้:{machine}\nสินค้า:{product}\nจำนวน:{amount}\nราคา:{price}\n\nRAWDATA:{tag}\n\nurl:https://api.gsquare.app/pic/{tag}");
            }
            catch
            {
                //
            }

            return File(Helper.Helper.GetQr(tag, _env.WebRootFileProvider.GetFileInfo("Thai_QR_Payment_Logo-03.png")?.PhysicalPath), "image/png");
        }

    }

    
}
