namespace _01.CRUD_API.Models
{
    public class UpdateOrderDto
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
    }
}
