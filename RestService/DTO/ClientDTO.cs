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
        public int Id { get; set; }

        [JsonProperty("pass")]
        public string Password { get; set; }

        [JsonProperty("response.client.name")]
        public string Name { get; set; }

        [JsonProperty("response.client.segment")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientSegment Segment { get; set; }

        public static explicit operator Client(ClientDTO dto)
        {
            return new Client() {
                ClientId = dto.Id,
                Password = dto.Password,
                Name = dto.Name,
                Segment = dto.Segment
            };
        }
    }
}
