namespace AuthPrac.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
