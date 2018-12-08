using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSBL.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Chestionar()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
