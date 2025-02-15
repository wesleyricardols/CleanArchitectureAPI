using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal price);
}