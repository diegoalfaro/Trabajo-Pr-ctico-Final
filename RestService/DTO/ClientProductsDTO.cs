using Newtonsoft.Json;
using RestService.Converters;
using System.Collections.Generic;

namespace RestService.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class ClientProductsDTO
    {
        [JsonProperty("id")]
        public int ClientId { get; set; }

        [JsonProperty("response.product")]
        public List<ProductDTO> Products { get; set; }
    }
}
