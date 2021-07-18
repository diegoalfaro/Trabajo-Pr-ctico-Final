using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class AccountMovement
    {
        [Key]
        public string AccountMovementId { get; set; }
        public string Date { get; set; }
        public double Ammount { get; set; }
    }
}
