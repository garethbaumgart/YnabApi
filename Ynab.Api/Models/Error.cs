using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class Error
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("detail")]
        public string Detail { get; set; }
    }
}