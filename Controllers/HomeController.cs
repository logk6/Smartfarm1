using Microsoft.AspNetCore.Mvc;
using Smartfarm1.Models;
using System.Diagnostics;
using System.Collections.Generic;

using System.Text;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.Sockets;
using System.Net;

namespace Smartfarm1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //private readonly ILogger<HomeController> _logger = ; //ILogger<HomeController> logger;

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Loged(IFormCollection form)
        {
            ViewBag.Loged = true;
            //string usrname = form["uname"];
            //string passw = form["psw"];
                
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Admin()
        {
            //IEnumerable<User> objCate = _usr.Users;
            //objCate = objCate.OrderBy(obj => obj.Id);
            return View();
        }

        public IActionResult Smartfarm() 
        {
            IEnumerable<Smartfarm> objCate = _db.Smartfarm;
            objCate = objCate.OrderBy(obj => obj.Id);

            return View(objCate);
        }

        [HttpPost]
        public IActionResult AddSmartfarm(IFormCollection form)
        {
            string str;
            Smartfarm farmadd = new Smartfarm();
            str = form["id"];
            farmadd.Id = Convert.ToInt32(str);
            farmadd.Name = form["name"];
            farmadd.IPAddress = form["ip"];

            _db.Smartfarm.Add(farmadd);
            _db.SaveChanges();

            return RedirectToAction("Smartfarm", "Home");
        }

        [HttpPost]
        public JsonResult SmartfarmGo(Smartfarm farmgo)
        {
            ViewBag.farmgoId = Convert.ToInt32(farmgo.Id);
            //ViewBag.farmgoIP = Convert.ToString(farmgo.IPAddress);
            return new JsonResult(Ok());
        }

        [HttpGet]
        public JsonResult Check(Contrl cm)
        {
            /**/
            IEnumerable<Smartfarm> objCate = _db.Smartfarm;
            objCate = objCate.OrderBy(obj => obj.Id);
            bool[] chec = new bool[objCate.Count()];

            int ind = 0;
            foreach (Smartfarm farm in objCate)
            {
                try
                {
                    string ip = farm.IPAddress;// "172.31.98.24"; //cm.ip;// ;
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
                    /*string strg = Encoding.ASCII.GetString(messageReceived).Replace("\0", string.Empty);

                    //var cate = JsonSerializer.Deserialize<FarmStatus>(strg);
                    var cate = JsonConvert.DeserializeObject<Check>(strg);*/
                    chec[ind] = true;
                    sender.Close();
                }
                catch (Exception ex) 
                {
                    chec[ind] = false;
                }
                ind++;
            }

            return new JsonResult(Ok(chec));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
