namespace OnlineStoreSystem.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public required ProductCategory Category { get; set; }
        public bool Is_Available { get; set; }


        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
    public enum ProductCategory
    {
        Electronics,
        clothing,
        Books,
        sports
    }
}
