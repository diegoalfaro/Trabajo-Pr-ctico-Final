using Domain;
using Newtonsoft.Json;

namespace Service.DTO
{
    class AccountMovementDTO : AccountMovement
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("ammount")]
        public double Ammount { get; set; }
    }
}
