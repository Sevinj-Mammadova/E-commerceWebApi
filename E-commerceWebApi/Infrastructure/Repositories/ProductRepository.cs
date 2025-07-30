using E_commerceWebApi.Application.DTOs;
using E_commerceWebApi.Application.Interfaces;
using E_commerceWebApi.Domain.Entities;
using E_commerceWebApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerceWebApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<List<Product>> AddProductsAsync(string name, decimal price)
        {
            return null;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dataContext.Products.ToListAsync();
        }
    }
}
