namespace MyShopApi.Dto;

public class TransactionResponse
{
    public string? CustomerId { get; set; }
    public DateTime TransDate { get; set; }
    public List<PurchaseDetailResponse>? PurchaseDetail { get; set; }
}