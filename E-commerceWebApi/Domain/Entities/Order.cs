using System.ComponentModel.DataAnnotations;
using E_commerceWebApi.Domain.Enums;

namespace E_commerceWebApi.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
