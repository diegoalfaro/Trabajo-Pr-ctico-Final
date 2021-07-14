using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public ClientSegment Segment { get; set; }
    }
}
