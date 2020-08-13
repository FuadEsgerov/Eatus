using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace API.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult EmailConfirmed(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                return Redirect("/login");

            }


            return View();
        }
    }
}
