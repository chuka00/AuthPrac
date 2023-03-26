using System.ComponentModel.DataAnnotations;

namespace AuthPrac.Entities
{
    public class Vendor
    {
        public int VendorId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        
        public IList <Product> Products { get; set; }
    }

}
