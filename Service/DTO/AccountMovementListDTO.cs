using Newtonsoft.Json;
using Service.Converters;
using System.Collections.Generic;

namespace Service.DTO
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
