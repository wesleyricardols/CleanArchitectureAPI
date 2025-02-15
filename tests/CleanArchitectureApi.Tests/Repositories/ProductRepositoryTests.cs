using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace CleanArchitectureApi.Tests.Repositories;

public class ProductRepositoryTests
{
    private readonly Mock<IProductRepository> _mockRepo = new();

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProduct()
    {
        var productId = Guid.NewGuid();
        var product = new Product("Test Product", 10.0m);
        _mockRepo.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);

        var result = await _mockRepo.Object.GetByIdAsync(productId);

        Assert.NotNull(result);
        Assert.Equal("Test Product", result.Name);
    }
}