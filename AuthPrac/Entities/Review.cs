namespace AuthPrac.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int CustomerId { get; set; }
        public int VendorId { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public Customer Customer { get; set; }
        public Vendor Vendor { get; set; }
    }

}
