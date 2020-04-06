using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class Transaction : IEquatable<Transaction>
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("amount")]
        public long Amount { get; set; }
        [JsonPropertyName("memo")]
        public string Memo { get; set; }
        [JsonPropertyName("cleared")]
        public ClearedType Cleared { get; set; }
        [JsonPropertyName("approved")]
        public bool Approved { get; set; }
        [JsonPropertyName("flag_color")]
        public FlagColor FlagColor { get; set; }
        [JsonPropertyName("account_id")]
        public Guid AccountId { get; set; }
        [JsonPropertyName("payee_id")]
        public Guid PayeeId { get; set; }
        [JsonPropertyName("category_id")]
        public Guid CategoryId { get; set; }
        [JsonPropertyName("transfer_account_id")]
        public Guid TransferAccountId { get; set; }
        [JsonPropertyName("transfer_transaction_id")]
        public string TransferTransactionId { get; set; }
        [JsonPropertyName("matched_transaction_id")]
        public string MatchedTransactionId { get; set; }
        [JsonPropertyName("import_id")]
        public string ImportId { get; set; }
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }
        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }
        [JsonPropertyName("payee_name")]
        public string PayeeName { get; set; }
        [JsonPropertyName("category_name")]
        public string CategoryName { get; set; }
        [JsonPropertyName("subtransactions")]
        public IEnumerable<SubTransaction> SubTransactions { get; set; }

        public static bool operator ==(Transaction left, Transaction right) =>
            Equals(left, right);

        public static bool operator !=(Transaction left, Transaction right) =>
            !Equals(left, right);

        public bool Equals([AllowNull] Transaction other) =>
            (Id, Date, Amount, Memo, Cleared, Approved, FlagColor, AccountId, PayeeId, CategoryId, TransferAccountId, TransferTransactionId, MatchedTransactionId, ImportId, Deleted, AccountName, PayeeName, CategoryName, SubTransactions) ==
            (other.Id, other.Date, other.Amount, other.Memo, other.Cleared, other.Approved, other.FlagColor, other.AccountId, other.PayeeId, CategoryId, other.TransferAccountId, other.TransferTransactionId, other.MatchedTransactionId, other.ImportId, other.Deleted, other.AccountName, other.PayeeName, other.CategoryName, other.SubTransactions);
        
        public override bool Equals(object obj) =>
            (obj is Transaction transaction) && Equals(transaction);

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Date);
            hash.Add(Amount);
            hash.Add(Memo);
            hash.Add(Cleared);
            hash.Add(Approved);
            hash.Add(FlagColor);
            hash.Add(AccountId);
            hash.Add(PayeeId);
            hash.Add(CategoryId);
            hash.Add(TransferAccountId);
            hash.Add(TransferTransactionId);
            hash.Add(MatchedTransactionId);
            hash.Add(ImportId);
            hash.Add(Deleted);
            hash.Add(AccountName);
            hash.Add(PayeeName);
            hash.Add(CategoryName);
            hash.Add(SubTransactions);
            return hash.ToHashCode();
        }
    }
}