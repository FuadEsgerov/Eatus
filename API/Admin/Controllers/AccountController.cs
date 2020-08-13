using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories.AdminRepository;

namespace Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        public AccountController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = _adminRepository.Login(model.Email, model.Password);
                if (admin != null)
                {
                    admin.Token = Guid.NewGuid().ToString();
                    _adminRepository.UpdateToken(admin.Id, admin.Token);
                    Response.Cookies.Append("admin-token", admin.Token, new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        HttpOnly = true,
                        Expires = model.RememberMe ? DateTime.Now.AddYears(1) : DateTime.Now.AddDays(1)
                    });
                    return RedirectToAction("index","dashboard");
                }
                ModelState.AddModelError("Password", "E-poçt və ya şifrə yanlışdır");
            }

            return View(model);
        }
    }
}
