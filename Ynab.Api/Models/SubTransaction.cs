using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class SubTransaction : IEquatable<SubTransaction>
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }
        [JsonPropertyName("amount")]
        public long Amount { get; set; }
        [JsonPropertyName("memo")]
        public string Memo { get; set; }
        [JsonPropertyName("payee_id")]
        public Guid PayeeId { get; set; }
        [JsonPropertyName("payee_name")]
        public string PayeeName { get; set; }
        [JsonPropertyName("category_id")]
        public Guid CategoryId { get; set; }
        [JsonPropertyName("category_name")]
        public string CategoryName { get; set; }
        [JsonPropertyName("transfer_account_id")]
        public Guid TransferAccountId { get; set; }
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        public static bool operator ==(SubTransaction left, SubTransaction right) =>
            Equals(left, right);

        public static bool operator !=(SubTransaction left, SubTransaction right) =>
            !Equals(left, right);

        public bool Equals([AllowNull] SubTransaction other) =>
            (Id, TransactionId, Amount, Memo, PayeeId, PayeeName, CategoryId, CategoryName, TransferAccountId) ==
            (other.Id, other.TransactionId, other.Amount, other.Memo, other.PayeeId, other.PayeeName, other.CategoryId, other.CategoryName, other.TransferAccountId);

        public override bool Equals(object obj) =>
            (obj is SubTransaction subTransaction) && Equals(subTransaction);

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(TransactionId);
            hash.Add(Amount);
            hash.Add(Memo);
            hash.Add(PayeeId);
            hash.Add(PayeeName);
            hash.Add(CategoryId);
            hash.Add(CategoryName);
            hash.Add(TransferAccountId);
            hash.Add(Deleted);
            return hash.ToHashCode();
        }
    }
}