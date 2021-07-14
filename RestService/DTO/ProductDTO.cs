using Domain;
using Newtonsoft.Json;
using RestService.Converters;

namespace RestService.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class ProductDTO
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public static explicit operator Product(ProductDTO dto)
        {
            return new Product()
            {
                Number = dto.Number,
                Name = dto.Name,
                Type = dto.Type,
            };
        }
    }
}
