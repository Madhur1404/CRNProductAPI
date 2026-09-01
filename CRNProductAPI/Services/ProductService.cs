using CRNProductAPI.DTOs;
using CRNProductAPI.Models;
using CRNProductAPI.Repositories;

namespace CRNProductAPI.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Product> CreateAsync(ProductCreateDto dto)
    {
        var product = new Product
        {
            ProductName = dto.ProductName,
            CreatedBy = dto.CreatedBy,
            CreatedOn = DateTime.UtcNow
        };

        return await _repository.CreateAsync(product);
    }

    public async Task<bool> UpdateAsync(int id, ProductUpdateDto dto)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is null)
            return false;

        product.ProductName = dto.ProductName;
        product.ModifiedBy = dto.ModifiedBy;
        product.ModifiedOn = DateTime.UtcNow;

        await _repository.UpdateAsync(product);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is null)
            return false;

        await _repository.DeleteAsync(product);

        return true;
    }
}