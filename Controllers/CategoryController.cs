using Microsoft.AspNetCore.Mvc;
using Smartfarm1.Models;
using System.Collections.Generic;
using System.Net;
using static System.Net.Sockets.Socket;
//using System.Text.Json;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;





namespace Smartfarm1.Controllers
{
    public class Req
    {
        public string mess { get; set; }
        public int rgb1 { get; set; }
        public int rgb2 { get; set; }
        public int rgb3 { get; set; }
    }

    public class Check
    {
        public bool fancheck { get; set; }
        public bool windowcheck { get; set; }
        public int rgb1 { get; set; }
        public int rgb2 { get; set; }
        public int rgb3 { get; set; }
    }

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
            objCate = objCate.OrderBy(obj => obj.DateTime);
           
            return View(objCate);
        }

        public IActionResult Contr()
        {
            
            return View();
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


        [HttpPost]
        public JsonResult Dkhien(Req cm)
        {
            if (cm.mess == null) {
                return new JsonResult("cm");
            }

            string ip = "172.31.98.24";
            IPAddress ipAddr = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 40674);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(localEndPoint);

            Req req = cm;// new Req { mess = cm.mess };
            string reqstrg = JsonConvert.SerializeObject(req);
            byte[] messageSent = Encoding.ASCII.GetBytes(reqstrg);
            int byteSent = sender.Send(messageSent);
            

            sender.Close();

            return new JsonResult(Ok(cm));
        }

        [HttpGet]
        public JsonResult Check()
        {
            /**/
            string ip = "172.31.98.24";
            IPAddress ipAddr = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 40674);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(localEndPoint);

            Req req = new Req { mess = "check" };
            string reqstrg = JsonConvert.SerializeObject(req);
            byte[] messSend = Encoding.ASCII.GetBytes(reqstrg);
            sender.Send(messSend);

            byte[] messageReceived = new byte[2048]; byte[] checkmess = new byte[1024];
            int byteRecv = sender.Receive(messageReceived);
            string strg = Encoding.ASCII.GetString(messageReceived).Replace("\0", string.Empty);

            //var cate = JsonSerializer.Deserialize<FarmStatus>(strg);
            var cate = JsonConvert.DeserializeObject<Check>(strg);


            sender.Close();
            

            return new JsonResult(Ok(cate));
        }


        [HttpGet]
        public JsonResult Sochchet()
        {//10.10.12.194 172.31.99.167
            string ip = "172.31.98.24";
            IPAddress ipAddr = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 40674);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(localEndPoint);

            Req req = new Req { mess = "measre" };
            string reqstrg = JsonConvert.SerializeObject(req);
            byte[] messSend = Encoding.ASCII.GetBytes(reqstrg);
            sender.Send(messSend);

            byte[] messageReceived = new byte[2048]; byte[] checkmess = new byte[1024];
            int byteRecv = sender.Receive(messageReceived);
            string strg = Encoding.ASCII.GetString(messageReceived).Replace("\0", string.Empty);

            //var cate = JsonSerializer.Deserialize<FarmStatus>(strg);
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
            objCate = objCate.OrderBy(obj => obj.DateTime);

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
            IEnumerable<FarmStatus> objCate = _db.FarmStatus;//pets.OrderBy(pet => pet.Age);
            objCate = objCate.OrderBy(obj => obj.DateTime);

            ViewBag.modcount = objCate.Count();
            return new JsonResult(Ok(objCate));

        }



    }
}
