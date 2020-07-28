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
        Task<IEnumerable<Department>> GetDepartmentsWithCategoryAsync();
        Task<IReadOnlyList<Department>> GetDepartmentsAsync();
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department> GetDepartmentByIdAsync(int id);
        void UpdateDepartment(Department deparmentToUpdate, Department department);
        void DeleteDepartment(Department department);
    }
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Department> CreateDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.Include(d => d.Brands).FirstOrDefaultAsync(p => p.Id == id);
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

        public void UpdateDepartment(Department deparmentToUpdate, Department department)
        {
            throw new NotImplementedException();
        }
    }
}
