using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Repositories;
using Repository.Repositories.ShoppingRepositories;

namespace API.Controllers
{
    [ApiController]

    [Route("api")]
    public class DepartmentController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IGenericRepository<Department> _departmentRepo;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IProductRepository _productRepository;

        public DepartmentController( IMapper mapper,IGenericRepository<Department> departmentRepo, IDepartmentRepository departmentRepository,IProductRepository productRepository)
        {
            _mapper = mapper;
           
            _departmentRepo = departmentRepo;
            _departmentRepository = departmentRepository;
            _productRepository = productRepository;

        }
        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<Department>>> GetDepartmentsAsync()
        {
            return Ok(await _departmentRepo.ListAllAsync());
        }
        [HttpGet("categories/restaurants")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartmentsWithCategoryAsync()
        {
            var departments = await _departmentRepository.GetDepartmentsWithCategoryAsync();

            var model = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departments);

            return Ok(model);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentByIdAsync(int id)
        {
            var departments = await _departmentRepository.GetDepartmentByIdAsync(id);

            var model = _mapper.Map<Department, DepartmentDto>(departments);

            return Ok(model);
        }
        //[HttpGet("{name}")]

        //public async Task<ActionResult<Department>> GetDepartmentByNameAsync(string name)
        //{
        //    var departments = await _departmentRepository.GetDepartmentByNameAsync(name);

        //    var model = _mapper.Map<Department, DepartmentDto>(departments);

        //    return Ok(model);
        //}
        [HttpGet("category/{id}")]
        public async Task<ActionResult<Product>> GetResult(int id)
        {
            var brand = await _departmentRepository.GetBrandByIdAsync(id);
            if (brand == null) return NotFound(new ApiResponse(404));
            var products = await _productRepository.GetProductsByBrandIdAsync(brand.Id);
            if (products == null) return NotFound(new ApiResponse(404));
            var model = new BrandListDto
            {
                Brand = _mapper.Map<ProductBrand, BrandDto>(brand),
                Products = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products)
            };

            return Ok(model);


        }

    }
}
