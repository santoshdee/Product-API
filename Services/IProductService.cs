using ProductApi.DTOs;

namespace ProductApi.Services
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto? GetById(int id);
        ProductDto Create(CreateProductDto dto);
        bool Update(int id, UpdateProductDto dto);
        bool Delete(int id);
    }
}