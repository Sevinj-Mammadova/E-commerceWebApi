using System.ComponentModel.DataAnnotations;

namespace E_commerceWebApi.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
