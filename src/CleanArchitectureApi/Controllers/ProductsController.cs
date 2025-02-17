using Application.DTOs;
using Application.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IProductManager manager) : ControllerBase
{   
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto dto)
    {
        await manager.CreateProductAsync(dto);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var product = await manager.GetProductByIdAsync(id);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductDto dto)
    {
        await manager.UpdateProductAsync(id, dto);
        return Ok("sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await manager.DeleteProductAsync(id);
        return NoContent();
    }
}