using Newtonsoft.Json;
using RestService.Converters;
using System.Collections.Generic;

namespace RestService.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class AccountMovementListDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("response.movements")]
        public List<AccountMovementDTO> Movements { get; set; }
    }
}
