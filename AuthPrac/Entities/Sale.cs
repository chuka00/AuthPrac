namespace AuthPrac.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public Customer Customer { get; set; }
        public Product Products { get; set; }
    }

}
