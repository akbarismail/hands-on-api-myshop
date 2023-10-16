using MyShopApi.Entities;
using MyShopApi.Exceptions;
using MyShopApi.Repositories;

namespace MyShopApi.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IPersistence _persistence;

    public ProductService(IRepository<Product> productRepository, IPersistence persistence)
    {
        _productRepository = productRepository;
        _persistence = persistence;
    }

    public async Task<Product> Create(Product payload)
    {
        var entryProduct = await _productRepository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return entryProduct;
    }

    public async Task<Product> GetById(string id)
    {
        try
        {
            var idProduct = await _productRepository.FindByIdAsync(Guid.Parse(id));
            if (idProduct is null) throw new NotFoundException("Product is not found");
            return idProduct;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Product>> GetAll()
    {
        return await _productRepository.FindAllAsync();
    }

    public async Task<Product> Update(Product payload)
    {
        var updateProduct = _productRepository.Update(payload);
        await _persistence.SaveChangesAsync();
        return updateProduct;
    }

    public async Task DeleteById(string id)
    {
        var idProduct = await GetById(id);
        _productRepository.Delete(idProduct);
        await _persistence.SaveChangesAsync();
    }
}