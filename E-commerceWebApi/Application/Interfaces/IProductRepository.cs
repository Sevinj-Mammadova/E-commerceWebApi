using E_commerceWebApi.Domain.Entities;

namespace E_commerceWebApi.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> AddProductsAsync();
    }
}
