namespace OnlineStoreSystem.Models.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public required decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }


        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();



    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Processing,
        Delivered,
        Cancelled
    }
}
