using Microsoft.AspNetCore.Mvc;
using MyShopApi.Entities;
using MyShopApi.Services;

namespace MyShopApi.Controllers;

[ApiController]
[Route("api/transactions")]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;

    public PurchaseController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewTransaction([FromBody] Purchase payload)
    {
        var transaction = await _purchaseService.CreateTransaction(payload);
        return Created("/api/transactions", transaction);
    }
}