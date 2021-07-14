using Domain;
using Newtonsoft.Json;
using RestService.Converters;

namespace RestService.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class ProductResetDTO
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("response.error")]
        public int Error { get; set; }

        [JsonProperty("response.error-description")]
        public string ErrorDescription { get; set; }

        public static explicit operator ProductReset(ProductResetDTO dto)
        {
            return new ProductReset()
            {
                Number = dto.Number,
                Error = dto.Error,
                ErrorDescription = dto.ErrorDescription,
            };
        }
    }
}
