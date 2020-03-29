using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class Account
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("checking")]
        public string Checking { get; set; }
        [JsonPropertyName("on_budget")]
        public bool OnBudget { get; set; }
        [JsonPropertyName("closed")]
        public bool Closed { get; set; }
        [JsonPropertyName("note")]
        public string Note { get; set; }
        [JsonPropertyName("balance")]
        public int Balance { get; set; }
        [JsonPropertyName("cleared_balance")]
        public int ClearedBalance { get; set; }
        [JsonPropertyName("transfer_payee_id")]
        public string TransferPayeeId { get; set; }
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }
    }
}