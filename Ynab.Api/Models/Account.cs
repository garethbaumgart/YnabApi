using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class Account : IEquatable<Account>
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public AccountType Type { get; set; }
        [JsonPropertyName("on_budget")]
        public bool OnBudget { get; set; }
        [JsonPropertyName("closed")]
        public bool Closed { get; set; }
        [JsonPropertyName("note")]
        public string Note { get; set; }
        [JsonPropertyName("balance")]
        public long Balance { get; set; }
        [JsonPropertyName("cleared_balance")]
        public long ClearedBalance { get; set; }
        [JsonPropertyName("uncleared_balance")]
        public long UnclearedBalance { get; set; }
        [JsonPropertyName("transfer_payee_id")]
        public Guid TransferPayeeId { get; set; }
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        public static bool operator ==(Account left, Account right) =>
            Equals(left, right);

        public static bool operator !=(Account left, Account right) =>
            !Equals(left, right);

        public bool Equals([AllowNull] Account other) =>
            (Id, Name, Type, OnBudget, Closed, Note, Balance, ClearedBalance, UnclearedBalance, TransferPayeeId, Deleted) ==
            (other.Id, other.Name, other.Type, other.OnBudget, other.Closed, other.Note, other.Balance, other.ClearedBalance, other.UnclearedBalance, other.TransferPayeeId, other.Deleted);

        public override bool Equals(object obj) =>
            (obj is Account account) && Equals(account);

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Type);
            hash.Add(OnBudget);
            hash.Add(Closed);
            hash.Add(Note);
            hash.Add(Balance);
            hash.Add(ClearedBalance);
            hash.Add(UnclearedBalance);
            hash.Add(TransferPayeeId);
            hash.Add(Deleted);
            return hash.ToHashCode();
        }
    }
}