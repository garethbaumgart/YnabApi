using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class TransactionData
    {
        public TransactionData(){}
        public TransactionData(IEnumerable<Transaction> transactions)
        {
            Transactions = transactions;
        }
        
        [JsonPropertyName("transactions")]
        public IEnumerable<Transaction> Transactions { get; }
        [JsonPropertyName("server_knowledge")]
        public int ServerKnowledge { get; set; }

    }
}