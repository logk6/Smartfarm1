using Microsoft.AspNetCore.Mvc;
using Smartfarm1.Models;
using System.Diagnostics;
using System.Collections.Generic;

using System.Text;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Smartfarm1.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _usr;
        public HomeController(ApplicationDbContext usr)
        {
            _usr = usr;
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

   

       

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
