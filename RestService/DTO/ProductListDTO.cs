using Newtonsoft.Json;
using RestService.Converters;
using System.Collections.Generic;

namespace RestService.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class ProductListDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("response.product")]
        public List<ProductDTO> Products { get; set; }
    }
}
