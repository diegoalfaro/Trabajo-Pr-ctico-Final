using Domain;
using Newtonsoft.Json;
using Service.Converters;

namespace Service.DTO
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
