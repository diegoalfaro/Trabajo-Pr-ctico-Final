using Domain;
using Newtonsoft.Json;
using Service.Converters;

namespace Service.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class ProductResetDTO : ProductReset
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("response.error")]
        public int Error { get; set; }

        [JsonProperty("response.error-description")]
        public string ErrorDescription { get; set; }
    }
}
