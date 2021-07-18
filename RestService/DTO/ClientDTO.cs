using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestService.Converters;

namespace RestService.DTO
{
    [JsonConverter(typeof(JsonPathConverter))]
    class ClientDTO
    {
        [JsonProperty("id")]
        public int ClientId { get; set; }

        [JsonProperty("pass")]
        public string Password { get; set; }

        [JsonProperty("response.client.name")]
        public string Name { get; set; }

        [JsonProperty("response.client.segment")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientSegment Segment { get; set; }

        public static implicit operator Client(ClientDTO dto)
        {
            return dto != null ? new Client() {
                ClientId = dto.ClientId,
                Password = dto.Password,
                Name = dto.Name,
                Segment = dto.Segment
            } : null;
        }
    }
}
