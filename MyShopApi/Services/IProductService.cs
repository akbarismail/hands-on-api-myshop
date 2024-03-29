using MyShopApi.Entities;

namespace MyShopApi.Services;

public interface IProductService
{
    Task<Product> Create(Product payload);
    Task<Product> GetById(string id);
    Task<List<Product>> GetAll();
    Task<Product> Update(Product payload);
    Task DeleteById(string id);
}