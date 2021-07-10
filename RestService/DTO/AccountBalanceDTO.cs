using Domain;
using Newtonsoft.Json;
using RestService.Converters;

namespace RestService.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class AccountBalanceDTO: AccountBalance
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("response.balance")]
        public double Balance { get; set; }
    }
}
