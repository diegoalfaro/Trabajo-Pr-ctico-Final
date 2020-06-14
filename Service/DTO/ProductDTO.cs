using Domain;
using Newtonsoft.Json;

namespace Service.DTO
{
    class ProductDTO : Product
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
