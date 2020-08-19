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
using Repository.Repositories;
using Repository.Repositories.ShoppingRepositories;
using Repository.Services;

namespace Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        public ProductsController(IMapper mapper,
                                  IProductRepository productRepository,
                                  ICloudinaryService cloudinaryService,
                                  IFileManager fileManager,
                                  IDepartmentRepository departmentRepository
                                )
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
            _departmentRepository = departmentRepository;
       
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetProducts();

            var model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentRepository.GetDepartments();
            ViewBag.Types = _productRepository.GetTypes();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = _mapper.Map<ProductViewModel, Product>(model);

                _productRepository.CreateProduct(product);

                return RedirectToAction("index");
            }

            return View(model);
        }


        public IActionResult Edit(int id)
        {
            Product product = _productRepository.GetProductById(id);

            if (product == null) return NotFound();

            var model = _mapper.Map<Product, ProductViewModel>(product);
    

            ViewBag.Departments = _departmentRepository.GetDepartments();
            ViewBag.Brands = _departmentRepository.GetCategoriesByDepartmentId(model.DepartmentId);
            ViewBag.Types = _productRepository.GetTypes();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = _mapper.Map<ProductViewModel, Product>(model);

                Product productToUpdate = _productRepository.GetProductById(model.Id);

                if (productToUpdate == null) return NotFound();

                _productRepository.UpdateProduct(productToUpdate, product);

                return RedirectToAction("index");
            }
            ViewBag.Departments = _departmentRepository.GetDepartments();
            ViewBag.Brands = _departmentRepository.GetCategoriesByDepartmentId(model.DepartmentId);
            ViewBag.Types = _productRepository.GetTypes();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Product product = _productRepository.GetProductById(id);

            if (product == null) return NotFound();

            _productRepository.DeleteProduct(product);

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file, int? productId)
        {
            var filename = _fileManager.Upload(file);
            var publicId = _cloudinaryService.Store(filename);
            _fileManager.Delete(filename);

            if (productId != null)
            {
                Product productPhoto = new Product
                {

                    Image = publicId,


                };
                _productRepository.AddPhoto(productPhoto);
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
                _productRepository.RemovePhotoById((int)id);
            }

            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }


    public IActionResult Brands(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);

            if (department == null) return NotFound();

            var brands = _departmentRepository.GetCategoriesByDepartmentId(department.Id);

            return Ok(brands.Select(c => new { c.Id, c.Name }).ToList());
        }


    }
}
