using MyShopApi.Dto;
using MyShopApi.Entities;
using MyShopApi.Repositories;

namespace MyShopApi.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IRepository<Purchase> _purchaseRepository;
    private readonly IPersistence _persistence;
    private readonly IProductService _productService;

    public PurchaseService(IRepository<Purchase> purchaseRepository, IPersistence persistence, IProductService productService)
    {
        _purchaseRepository = purchaseRepository;
        _persistence = persistence;
        _productService = productService;
    }

    public async Task<TransactionResponse> CreateTransaction(Purchase payload)
    {
        await _persistence.BeginTransactionAsync();
        try
        {
            payload.TransDate = DateTime.Now;
            var purchase = await _purchaseRepository.SaveAsync(payload);
            await _persistence.SaveChangesAsync();

            if (purchase.PurchaseDetails != null)
                foreach (var purchaseDetail in purchase.PurchaseDetails)
                {
                    var product = await _productService.GetById(purchaseDetail.ProductId.ToString());
                    product.Stock -= purchaseDetail.Qty;
                }

            await _persistence.SaveChangesAsync();
            await _persistence.CommitTransactionAsync();

            var purchaseDetailResponse = new List<PurchaseDetailResponse>();
            if (purchase.PurchaseDetails != null) purchaseDetailResponse.AddRange(purchase.PurchaseDetails
                .Select(purchaseDetail => new PurchaseDetailResponse
                {
                    ProductId = purchaseDetail.ProductId.ToString(), 
                    Qty = purchaseDetail.Qty
                }));

            TransactionResponse response = new()
            {
                CustomerId = purchase.CustomerId.ToString(),
                TransDate = purchase.TransDate,
                PurchaseDetail = purchaseDetailResponse
            };

            return response;
        }
        catch (Exception)
        {
            await _persistence.RollBackTransactionAsync();
            throw;
        }
    }
}