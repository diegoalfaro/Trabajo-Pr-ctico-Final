using Domain;
using Newtonsoft.Json;
using RestService.Converters;

namespace RestService.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class AccountBalanceDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("response.balance")]
        public double Balance { get; set; }

        public static explicit operator AccountBalance(AccountBalanceDTO dto)
        {
            return new AccountBalance()
            {
                AccountBalanceId = dto.Id,
                Balance = dto.Balance
            };
        }
    }
}
