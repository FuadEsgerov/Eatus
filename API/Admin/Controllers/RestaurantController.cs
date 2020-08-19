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
    public class RestaurantController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;

        public RestaurantController(ICloudinaryService cloudinaryService, IDepartmentRepository departmentRepository, IMapper mapper, IFileManager fileManager)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;
        }

        public IActionResult Index()
        {
            ViewBag.Departments = _departmentRepository.GetDepartments();
            var brands = _departmentRepository.GetBrands();

            var model = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandViewModel>>(brands);

            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _departmentRepository.GetDepartments();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProductBrand brand = _mapper.Map<BrandViewModel, ProductBrand>(model);


                _departmentRepository.CreateBrand(brand);

                return RedirectToAction("index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
         
            ProductBrand brand = _departmentRepository.GetBrandById(id);

            if (brand == null) return NotFound();

            var model = _mapper.Map<ProductBrand, BrandViewModel>(brand);

            ViewBag.Departments = _departmentRepository.GetDepartments();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProductBrand brand = _mapper.Map<BrandViewModel, ProductBrand>(model);

                ProductBrand brandToUpdate = _departmentRepository.GetBrandById(model.Id);

                if (brandToUpdate == null) return NotFound();

                _departmentRepository.UpdateBrand(brandToUpdate, brand);

                return RedirectToAction("index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            ProductBrand brand = _departmentRepository.GetBrandById(id);

            if (brand == null) return NotFound();

            _departmentRepository.DeleteBrand(brand);

            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Upload(IFormFile file, int? brandId)
        {
            var filename = _fileManager.Upload(file);
            var publicId = _cloudinaryService.Store(filename);
            _fileManager.Delete(filename);

            if (brandId != null)
            {
                ProductBrand brandPhoto = new ProductBrand
                {

                    Image = publicId,


                };
                _departmentRepository.AddPhoto(brandPhoto);
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
