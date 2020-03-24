using Newtonsoft.Json;

namespace Ynab.Api.Models
{
    public class Error
    {
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("detail")]
        public string Detail;
    }
}