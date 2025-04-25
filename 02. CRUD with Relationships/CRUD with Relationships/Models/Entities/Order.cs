using System.ComponentModel.DataAnnotations;

namespace CRUD_with_Relationships.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
