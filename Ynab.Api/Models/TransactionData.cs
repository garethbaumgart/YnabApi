using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class TransactionData : IEquatable<TransactionData>
    {
        [JsonPropertyName("transactions")]
        public IEnumerable<Transaction> Transactions { get; set; }
        [JsonPropertyName("server_knowledge")]
        public int ServerKnowledge { get; set; }

        public static bool operator ==(TransactionData left, TransactionData right) =>
            Equals(left, right);

        public static bool operator !=(TransactionData left, TransactionData right) =>
            !Equals(left, right);

        public bool Equals([AllowNull] TransactionData other) =>
            Transactions.SequenceEqual(other.Transactions) &&
            ServerKnowledge.Equals(other.ServerKnowledge);
        
        public override bool Equals(object obj) =>
            (obj is TransactionData transactionData) && Equals(transactionData);

        public override int GetHashCode() =>
            HashCode.Combine(Transactions, ServerKnowledge);
    }
}