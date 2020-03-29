using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class Account : IEquatable<Account>
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

        public static bool operator ==(Account left, Account right) =>
            Equals(left, right);

        public static bool operator !=(Account left, Account right) =>
            !Equals(left, right);

        public bool Equals([AllowNull] Account other) =>
            (Id, Name, Checking, OnBudget, Closed, Note, Balance, ClearedBalance, TransferPayeeId, Deleted) ==
            (other.Id, other.Name, other.Checking, other.OnBudget, other.Closed, other.Note, other.Balance, other.ClearedBalance, other.TransferPayeeId, other.Deleted);

        public override bool Equals(object obj) =>
            (obj is Account account) && Equals(account);

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Checking);
            hash.Add(OnBudget);
            hash.Add(Closed);
            hash.Add(Note);
            hash.Add(Balance);
            hash.Add(ClearedBalance);
            hash.Add(TransferPayeeId);
            hash.Add(Deleted);
            return hash.ToHashCode();
        }
    }
}