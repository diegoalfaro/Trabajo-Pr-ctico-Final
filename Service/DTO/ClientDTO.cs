using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Service.Converters;

namespace Service.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class ClientDTO: Client
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("pass")]
        public string Password { get; set; }

        [JsonProperty("response.client.name")]
        public string Name { get; set; }

        [JsonProperty("response.client.segment")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientSegment Segment { get; set; }
    }
}
