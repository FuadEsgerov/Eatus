using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.ShoppingRepositories
{
    public interface IDepartmentRepository
    {
        Task<ProductBrand> GetBrandByIdAsync(int id);
        Task<IEnumerable<Department>> GetDepartmentsWithCategoryAsync();
        Task<IReadOnlyList<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<Department> GetDepartmentByNameAsync(string name);
        Department GetDepartmentById(int id);
        IEnumerable<Department> GetDepartments();
        void UpdateDepartment(Department deparmentToUpdate, Department department);
        void DeleteDepartment(Department department);
        Department CreateDepartment(Department department);
    }
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Department CreateDepartment(Department department)
        {
       

            _context.Departments.Add(department);

            _context.SaveChanges();

            return department;
        }



        public void DeleteDepartment(Department department)
        {
            _context.Departments.Remove(department);

            _context.SaveChanges();
        }

        public async Task<ProductBrand> GetBrandByIdAsync(int id)
        {
            return await _context.ProductBrands.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Departments.Find(id);
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.Include(d => d.Brands).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Department> GetDepartmentByNameAsync(string name)
        {
            return await _context.Departments.Include(d => d.Brands).FirstOrDefaultAsync(p => p.Name == name);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public async Task<IReadOnlyList<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

 

        public async Task<IEnumerable<Department>> GetDepartmentsWithCategoryAsync()
        {
            return await _context.Departments.Include(d => d.Brands).Where(d =>d.Status)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandNameAsync(int id)
        {
            return await _context.Products.Where(p => p.ProductBrandId == id).ToListAsync();
        }

        public void UpdateDepartment(Department deparmentToUpdate, Department department)
        {
            deparmentToUpdate.Status = department.Status;
            deparmentToUpdate.Name = department.Name;

            _context.SaveChanges();
        }
    }
}
