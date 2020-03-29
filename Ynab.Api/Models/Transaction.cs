using System;
using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class Transaction
    {
        public Transaction(int amount, string description, string accountId, DateTime date)
        {
            this.amount = amount;
            this.payee_name = description;
            this.date = date;
            this.account_id = accountId;
        }
        
        [JsonPropertyName("amount")]
        public int amount { get; }
        [JsonPropertyName("account_id")]
        public string account_id { get; }
        [JsonPropertyName("payee_name")]
        public string payee_name { get; }
        [JsonPropertyName("date")]
        public DateTime date { get; }
        [JsonPropertyName("cleared")]
        public string cleared => "cleared";
        [JsonPropertyName("approved")]
        public bool approved => true;
        [JsonPropertyName("flag_color")]
        public string flag_color => "purple";
        [JsonPropertyName("import_id")]
        public string import_id => Guid.NewGuid().ToString();
    }
}