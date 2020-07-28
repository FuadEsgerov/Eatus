using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByBrandIdAsync(int brandId);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }

    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.
                Include(p => p.ProductBrand).
                Include(p => p.ProductType).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.
                Include(p=>p.ProductBrand).
                Include(p => p.ProductType).ToListAsync();
        }

        public async Task<IEnumerable <Product>> GetProductsByBrandIdAsync(int brandId)
        {

            return await _context.Products.Where(p => p.ProductBrandId == brandId).ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
