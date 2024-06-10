using Microsoft.AspNetCore.Mvc;
using Smartfarm1.Models;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using System.Net;
using static System.Net.Sockets.Socket;
using System.Text.Json;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;




namespace Smartfarm1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var date = DateOnly.FromDateTime(DateTime.Now);
            ViewBag.FormattedDate = date.ToString("d"); // Lưu vào ViewBag



            IEnumerable<FarmStatus> objCate = _db.FarmStatus;

            return View(objCate);
        }

        public ActionResult FarmChart()
        {
            IEnumerable<FarmStatus> arr = _db.FarmStatus;
            //int s = arr.Count();
            var plotModel = new FarmChart(arr).MyModel;
            var stream = new MemoryStream();
            var exporter = new SvgExporter { Width = 850, Height = 550 };
            exporter.Export(plotModel, stream);
            stream.Position = 0;
            return File(stream, "image/svg+xml");
        }

        [HttpGet]
        public JsonResult GetName()
        {
            var name = new string[3]
            {
                "Ashley",
                "Belle",
                "Chanh"
            };

            return new JsonResult(Ok(name));
        }


        [HttpGet]
        public JsonResult Sochchet()
        {//10.10.12.194 172.31.99.167
            string ip = "172.31.98.6";
            IPAddress ipAddr = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 40674);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(localEndPoint);

            byte[] messageReceived = new byte[1024];
            int byteRecv = sender.Receive(messageReceived);
            string strg = Encoding.ASCII.GetString(messageReceived);
            var cate = JsonConvert.DeserializeObject<FarmStatus>(strg);


            sender.Close();
            /*
            if (cate != null)
            {
                _db.FarmStatus.Add(cate);
                _db.SaveChanges();
            }*/

            return new JsonResult(Ok(cate));
        }


        [HttpGet]
        public JsonResult Getsth()
        {
            IEnumerable<FarmStatus> objCate = _db.FarmStatus;
            ViewBag.modelcount = objCate.Count() - 1;
            FarmStatus va = new FarmStatus();
            foreach (FarmStatus obj in objCate)
            {
                va = obj;
            }

            return new JsonResult(Ok(va));
        }


        [HttpGet]
        public JsonResult Gigachart()
        {
            IEnumerable<FarmStatus> objCate = _db.FarmStatus;
            
            ViewBag.modcount = objCate.Count();
            return new JsonResult(Ok(objCate));

        }
       


    }
}
