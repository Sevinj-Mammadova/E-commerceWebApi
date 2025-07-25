﻿namespace E_commerceWebApi.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
