using Application.DTOs;
using Application.Managers.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Managers;

public class ProductManager(IProductRepository repository, IMapper mapper) : IProductManager
{
    public async Task<ProductDto> GetProductByIdAsync(Guid id)
    {
        var product = await repository.GetByIdAsync(id);
        return mapper.Map<ProductDto>(product);
    }

    public async Task CreateProductAsync(ProductDto dto)
    {
        var product = mapper.Map<Product>(dto);
        await repository.AddAsync(product);
    }

    public async Task UpdateProductAsync(Guid id, ProductDto dto)
    {
        var product = await repository.GetByIdAsync(id);
        mapper.Map(dto, product);
        if (product != null) await repository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        var product = await repository.GetByIdAsync(id);
        if (product != null) await repository.DeleteAsync(product.Id);
    }
}