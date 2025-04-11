namespace _01.CRUD_API.Models
{
    public class AddOrderDto
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
    }
}
