using MyShopApi.Dto;
using MyShopApi.Entities;

namespace MyShopApi.Services;

public interface IPurchaseService
{
    Task<TransactionResponse> CreateTransaction(Purchase payload);
} 