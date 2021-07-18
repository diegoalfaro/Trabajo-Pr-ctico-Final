using Newtonsoft.Json;
using RestService.Converters;
using System.Collections.Generic;

namespace RestService.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class ClientAccountMovementsDTO
    {
        [JsonProperty("id")]
        public int ClientId { get; set; }

        [JsonProperty("response.movements")]
        public List<AccountMovementDTO> Movements { get; set; }
    }
}
