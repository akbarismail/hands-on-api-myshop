using Microsoft.AspNetCore.Mvc;
using MyShopApi.Entities;
using MyShopApi.Services;

namespace MyShopApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewProduct([FromBody] Product payload)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var entryProduct = await _productService.Create(payload);
        return Created("/api/products", entryProduct);
    }

    [HttpGet]
    public async Task<IActionResult> FindAllProducts()
    {
        var products = await _productService.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var productId = await _productService.GetById(id);
        return Ok(productId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductById(string id)
    {
        await _productService.DeleteById(id);
        return Ok();
    }
}