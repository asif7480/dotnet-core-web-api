namespace CRUD_with_Relationships.Models.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
