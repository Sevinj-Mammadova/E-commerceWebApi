using E_commerceWebApi.Domain.Entities;
using System.Threading.Tasks;

namespace E_commerceWebApi.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task AddOrderAsync(Order order);
    }
}
