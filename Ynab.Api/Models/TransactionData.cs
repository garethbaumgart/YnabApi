using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ynab.Api.Models
{
    public class TransactionData
    {
        public TransactionData(){}
        public TransactionData(IEnumerable<Transaction> transactions)
        {
            Transactions = transactions;
        }
        
        [JsonProperty("transactions")]
        public IEnumerable<Transaction> Transactions;
        [JsonProperty("server_knowledge")]
        public int ServerKnowledge;

    }
}