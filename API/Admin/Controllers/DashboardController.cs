using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Filters;
using Admin.Models.Shopping;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Data.Identity;
using Repository.Entities.OrderAggregate;

namespace Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly AppIdentityDbContext _identity;
        public DashboardController(AppDbContext context, AppIdentityDbContext identity)
        {
            _context = context;
            _identity = identity;
        }
        [TypeFilter(typeof(Auth))]

        public IActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();

            dashboard.products_count = _context.Products.Count();
                
            dashboard.orders_count = _context.Orders.Count();
            dashboard.users_count = _identity.Users.Count();

            return View(dashboard);

        }
    }
}
