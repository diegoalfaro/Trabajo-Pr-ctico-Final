using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UserAction
    {
        [Key]
        public int ActionId { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
