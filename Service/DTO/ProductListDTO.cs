using Newtonsoft.Json;
using Service.Converters;
using System.Collections.Generic;

namespace Service.DTO
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
