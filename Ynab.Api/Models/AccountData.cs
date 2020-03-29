using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class AccountData
    {
        [JsonPropertyName("accounts")]
        public List<Account> Accounts { get; set; }
        [JsonPropertyName("server_knowledge")]
        public int ServerKnowledge { get; set; }
    }
}