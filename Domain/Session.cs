using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
