using Domain;
using Newtonsoft.Json;
using RestService.Converters;

namespace RestService.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class AccountBalanceDTO
    {
        [JsonProperty("id")]
        public int ClientId { get; set; }

        [JsonProperty("response.balance")]
        public double Balance { get; set; }

        public static implicit operator AccountBalance(AccountBalanceDTO dto)
        {
            return dto != null ? new AccountBalance()
            {
                ClientId = dto.ClientId,
                Balance = dto.Balance
            } : null;
        }
    }
}
