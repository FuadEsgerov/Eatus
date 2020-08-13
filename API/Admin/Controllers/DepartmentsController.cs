using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.Shopping;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Repositories.ShoppingRepositories;

namespace Admin.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IMapper mapper,
                                     IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var departments = _departmentRepository.GetDepartments();

            var model = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(departments);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department department = _mapper.Map<DepartmentViewModel, Department>(model);
             

                _departmentRepository.CreateDepartment(department);

                return RedirectToAction("index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Department department = _departmentRepository.GetDepartmentById(id);

            if (department == null) return NotFound();

            var model = _mapper.Map<Department, DepartmentViewModel>(department);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department department = _mapper.Map<DepartmentViewModel, Department>(model);

                Department deparmentToUpdate = _departmentRepository.GetDepartmentById(model.Id);

                if (deparmentToUpdate == null) return NotFound();

                _departmentRepository.UpdateDepartment(deparmentToUpdate, department);

                return RedirectToAction("index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Department department = _departmentRepository.GetDepartmentById(id);

            if (department == null) return NotFound();

            _departmentRepository.DeleteDepartment(department);

            return RedirectToAction("index");
        }
    }
}
