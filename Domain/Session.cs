using System;

namespace Domain
{
    public class Session
    {
        public int SessionId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
