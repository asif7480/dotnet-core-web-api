using System.ComponentModel.DataAnnotations;

namespace CRUD_with_Relationships.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
