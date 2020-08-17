using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Entities;
using Repository.Entities.OrderAggregate;
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
        //Admin
        IEnumerable<ProductBrand> GetBrands();
        ProductBrand CreateBrand(ProductBrand brand);
        ProductBrand GetBrandById(int id);
        void UpdateBrand(ProductBrand brandToUpdate, ProductBrand brand);
        void DeleteBrand(ProductBrand brand);
        void RemoveBrandPhotoById(int id);
        void AddPhoto(ProductBrand brandPhoto);
        //admin department
        Department GetDepartmentById(int id);
        IEnumerable<Department> GetDepartments();
        IEnumerable<Order> GetOrders();
        void UpdateDepartment(Department deparmentToUpdate, Department department);
        void DeleteDepartment(Department department);
        Department CreateDepartment(Department department);
        IEnumerable<ProductBrand> GetCategoriesByDepartmentId(int id);
        void RemovePhotoById(int id);
        void AddPhoto(Department departmentPhoto);
    }
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddPhoto(Department departmentPhoto)
        {
            _context.Departments.Add(departmentPhoto);
            _context.SaveChanges();
        }

        public void AddPhoto(ProductBrand brandPhoto)
        {
            _context.ProductBrands.Add(brandPhoto);
            _context.SaveChanges();
        }

        public ProductBrand CreateBrand(ProductBrand brand)
        {
            _context.ProductBrands.Add(brand);

            _context.SaveChanges();

            return brand;
        }

        public Department CreateDepartment(Department department)
        {
            _context.Departments.Add(department);

            _context.SaveChanges();

            return department;
        }

        public void DeleteBrand(ProductBrand brand)
        {
            _context.ProductBrands.Remove(brand);

            _context.SaveChanges();
        }

        public void DeleteDepartment(Department department)
        {
            _context.Departments.Remove(department);

            _context.SaveChanges();
        }

        public ProductBrand GetBrandById(int id)
        {
            return _context.ProductBrands.Find(id);
        }

        public async Task<ProductBrand> GetBrandByIdAsync(int id)
        {
            return await _context.ProductBrands.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<ProductBrand> GetBrands()
        {
            return _context.ProductBrands.ToList();
        }

        public IEnumerable<ProductBrand> GetCategoriesByDepartmentId(int id)
        {
            return _context.ProductBrands.Where(c => c.Status && c.DepartmentId == id).ToList();
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

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandNameAsync(int id)
        {
            return await _context.Products.Where(p => p.ProductBrandId == id).ToListAsync();
        }

        public void RemoveBrandPhotoById(int id)
        {
            ProductBrand brandPhoto = _context.ProductBrands.Find(id);

            _context.ProductBrands.Remove(brandPhoto);

            _context.SaveChanges();
        }

        public void RemovePhotoById(int id)
        {
            Department departmentPhoto = _context.Departments.Find(id);

            _context.Departments.Remove(departmentPhoto);

            _context.SaveChanges();
        }

        public void UpdateBrand(ProductBrand brandToUpdate, ProductBrand brand)
        {
            brandToUpdate.Status = brand.Status;
            brandToUpdate.Name = brand.Name;
            brandToUpdate.Image = brand.Image;
            brandToUpdate.Detail = brand.Detail;
            brandToUpdate.Address = brand.Address;
            brandToUpdate.DepartmentId = brand.DepartmentId;

            _context.SaveChanges();
        }

        public void UpdateDepartment(Department deparmentToUpdate, Department department)
        {
            deparmentToUpdate.Status = department.Status;
            deparmentToUpdate.Name = department.Name;
            deparmentToUpdate.Image = department.Image;

            _context.SaveChanges();
        }
    }
}
