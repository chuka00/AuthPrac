using System.ComponentModel.DataAnnotations;

namespace AuthPrac.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
