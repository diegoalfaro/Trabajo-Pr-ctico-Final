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

        public static explicit operator AccountMovement(AccountMovementDTO dto)
        {
            return new AccountMovement()
            {
                Date = dto.Date,
                Ammount = dto.Ammount
            };
        }
    }
}
