using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Libs;
using Admin.Models.Shopping;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Repositories.ShoppingRepositories;
using Repository.Services;

namespace Admin.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;

        public DepartmentsController(ICloudinaryService cloudinaryService, IDepartmentRepository departmentRepository, IMapper mapper, IFileManager fileManager)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;
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
        [HttpPost]
        public IActionResult Upload(IFormFile file, int? departmentId)
        {
            var filename = _fileManager.Upload(file);
            var publicId = _cloudinaryService.Store(filename);
            _fileManager.Delete(filename);

            if (departmentId != null)
            {
                Department departmentPhoto = new Department
                {
                 
                    Image = publicId,


                };
                _departmentRepository.AddPhoto(departmentPhoto);
            }

            return Ok(new
            {
                filename = publicId,
                src = _cloudinaryService.BuildUrl(publicId)
            });
        }

        [HttpPost]
        public IActionResult Remove(string name, int? id)
        {
            if (id != null)
            {
                _departmentRepository.RemovePhotoById((int)id);
            }

            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }
    }
}
