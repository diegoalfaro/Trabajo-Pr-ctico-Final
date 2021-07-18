using Domain;
using Newtonsoft.Json;

namespace RestService.DTO
{
    class AccountMovementDTO
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("ammount")]
        public double Ammount { get; set; }

        public static implicit operator AccountMovement(AccountMovementDTO dto)
        {
            return dto != null ? new AccountMovement()
            {
                Date = dto.Date,
                Ammount = dto.Ammount
            } : null;
        }
    }
}
