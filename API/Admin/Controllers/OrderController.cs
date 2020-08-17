using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.Shopping;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities.OrderAggregate;
using Repository.Repositories.ShoppingRepositories;

namespace Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;


        public OrderController( IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
     
        }
        public IActionResult Index()
        {
            var orders = _departmentRepository.GetOrders();

            var model = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);

            return View(model);
        }
    }
}
