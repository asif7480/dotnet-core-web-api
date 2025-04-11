namespace _01.CRUD_API.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
    }
}
