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
        Task<IEnumerable<Product>> GetProductsByBrandIdAsync(int brandId);
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        //AdminRepo
        IEnumerable<Product> GetProducts();
        IEnumerable<ProductType> GetTypes();
        Product CreateProduct(Product product);
        Product GetProductById(int id);
        void UpdateProduct(Product productToUpdate, Product product);
        void RemovePhotoById(int id);
        void AddPhoto(Product productPhoto);
        void DeleteProduct(Product product);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandIdAsync(int brandId)
        {

            return await _context.Products.Include(p=>p.ProductBrand).Include(p=>p.ProductType).Where(p => p.ProductBrandId == brandId)
                                    .Where(p => p.Status).ToListAsync();

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



        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);

            _context.SaveChanges();

            return product;
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void UpdateProduct(Product productToUpdate, Product product)
        {
            productToUpdate.Status = product.Status;
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Image = product.Image;
            productToUpdate.ProductTypeId = product.ProductTypeId;
            productToUpdate.Description = product.Description;         
            productToUpdate.ProductBrandId = product.ProductBrandId;
        
           }

        public void RemovePhotoById(int id)
        {
            Product productPhoto = _context.Products.Find(id);

            _context.Products.Remove(productPhoto);

            _context.SaveChanges();
        }

        public void AddPhoto(Product productPhoto)
        {
            _context.Products.Add(productPhoto);
            _context.SaveChanges();
        }

        public IEnumerable<ProductType> GetTypes()
        {
            return _context.ProductTypes.ToList();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);

            _context.SaveChanges();
        }
    }
}
