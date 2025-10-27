namespace OnlineStoreSystem.Models.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public required string Family { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthdate { get; set; }

        public DateTime Register_date { get; set; }
        public bool Is_Active { get; set; }


        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }

}
