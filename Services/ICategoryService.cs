using ProductApi.DTOs;

namespace ProductApi.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDto? GetById(int id);
        CategoryDto Create(CreateCategoryDto dto);
    }
}