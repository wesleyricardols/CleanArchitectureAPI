using Application.DTOs;

namespace Application.Managers.Interfaces;

public interface IProductManager
{
    Task<ProductDto> GetProductByIdAsync(Guid id);
    Task CreateProductAsync(ProductDto dto);
    Task UpdateProductAsync(Guid id, ProductDto dto);
    Task DeleteProductAsync(Guid id);
}