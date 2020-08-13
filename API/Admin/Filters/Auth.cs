using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Repository.Repositories.AdminRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Filters
{
    public class Auth : ActionFilterAttribute
    {
        private readonly IAdminRepository _adminRepository;

        public Auth(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Cookies.TryGetValue("admin-token", out string token))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new {  controller = "account" }));
            }

            var admin = _adminRepository.CheckByToken(token);

            if (admin == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new {  controller = "account" }));
            }

            var controller = context.Controller as Controller;
            if (controller != null)
            {
                controller.ViewBag.Admin = admin;
            }

            context.RouteData.Values["Admin"] = admin;
        }
    }
}
