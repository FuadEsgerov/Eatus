using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
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
        public DepartmentController( IMapper mapper,IGenericRepository<Department> departmentRepo, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
           
            _departmentRepo = departmentRepo;
            _departmentRepository = departmentRepository;

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
    }
}
