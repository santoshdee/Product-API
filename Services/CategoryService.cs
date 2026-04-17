using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs;
using ProductApi.Models;

namespace ProductApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public List<CategoryDto> GetAll()
        {
            return _context.Categories
            .Include(c => c.Products)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ProductNames = c.Products.Select(p => p.Name).ToList()
            })
            .ToList();
        }

        public CategoryDto? GetById(int id)
        {
            return _context.Categories
            .Include(c => c.Products)
            .Where(c => c.Id == id)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                ProductNames = c.Products.Select(p => p.Name).ToList()
            })
            .FirstOrDefault();
        }

        public CategoryDto Create(CreateCategoryDto dto)
        {
            var exists = _context.Categories
                        .Any(c => c.Name.ToLower() == dto.Name.ToLower());

            if(exists)
                throw new Exception("Category already exists");

            var category = new Category
            {
                Name = dto.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ProductNames = new List<string>()
            };
        }
    }
}