using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProductReset
    {
        [Key]
        public int ProductResetId { get; set; }
        public string Number { get; set; }
        public int Error { get; set; }
        public string ErrorDescription { get; set; }
    }
}
