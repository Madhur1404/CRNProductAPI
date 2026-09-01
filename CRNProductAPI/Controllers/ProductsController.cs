using CRNProductAPI.DTOs;
using CRNProductAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRNProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    // GET: api/products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAllAsync();

        return Ok(products);
    }

    // GET: api/products/1
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);

        if (product is null)
            return NotFound(new
            {
                message = $"Product with ID {id} was not found."
            });

        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto dto)
    {
        var product = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product);
    }

    // PUT: api/products/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        ProductUpdateDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
            return NotFound(new
            {
                message = $"Product with ID {id} was not found."
            });

        return NoContent();
    }

    // DELETE: api/products/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound(new
            {
                message = $"Product with ID {id} was not found."
            });

        return NoContent();
    }
}