using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ynab.Api.Models
{
    public class AccountData
    {
        [JsonProperty("accounts")]
        public List<Account> Accounts;
        [JsonProperty("server_knowledge")]
        public int ServerKnowledge;
    }
}