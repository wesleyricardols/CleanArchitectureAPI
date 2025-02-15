using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(Guid id) =>
        await context.Products.FindAsync(id);

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await context.Products.ToListAsync();

    public async Task AddAsync(Product entity)
    {
        await context.Products.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
    {
        context.Products.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            context.Products.Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal price) =>
        await context.Products.Where(p => p.Price <= price).ToListAsync();
}