using Newtonsoft.Json;

namespace Ynab.Api.Models
{
    public class Account
    {
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("checking")]
        public string Checking;
        [JsonProperty("on_budget")]
        public bool OnBudget;
        [JsonProperty("closed")]
        public bool Closed;
        [JsonProperty("note")]
        public string Note;
        [JsonProperty("balance")]
        public int Balance;
        [JsonProperty("cleared_balance")]
        public int ClearedBalance;
        [JsonProperty("transfer_payee_id")]
        public string TransferPayeeId;
        [JsonProperty("deleted")]
        public bool Deleted;
    }
}