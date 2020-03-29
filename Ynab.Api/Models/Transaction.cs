using System;
using Newtonsoft.Json;

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
        
        [JsonProperty("amount")]
        public int amount { get; }
        [JsonProperty("account_id")]
        public string account_id { get; }
        [JsonProperty("payee_name")]
        public string payee_name { get; }
        [JsonProperty("date")]
        public DateTime date { get; }
        [JsonProperty("cleared")]
        public string cleared => "cleared";
        [JsonProperty("approved")]
        public bool approved => true;
        [JsonProperty("flag_color")]
        public string flag_color => "purple";
        [JsonProperty("import_id")]
        public string import_id => Guid.NewGuid().ToString();
    }
}