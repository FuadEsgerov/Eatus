using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
