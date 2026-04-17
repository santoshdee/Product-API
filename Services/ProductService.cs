using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs;
using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductDto> GetAll()
        {
            return _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    CategoryName = p.Category.Name
                })
                .ToList();
        }

        public ProductDto? GetById(int id)
        {
            return _context.Products
                .Include(p => p.Category)
                .Where(p => p.Id == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    CategoryName = p.Category.Name
                })
                .FirstOrDefault();
        }

        public ProductDto Create(CreateProductDto dto)
        {
            var category = _context.Categories
                            .FirstOrDefault(c => c.Name.ToLower() == dto.CategoryName.ToLower());

            if (category == null)
                throw new Exception("Category not found");

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CategoryId = category.Id
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryName = category.Name
            };
        }

        public bool Update(int id, UpdateProductDto dto)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                return false;

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Description = dto.Description;
            product.CategoryId = dto.CategoryId;

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            _context.SaveChanges();

            return true;
        }
    }
}