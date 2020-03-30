using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class AccountData : IEquatable<AccountData>
    {
        [JsonPropertyName("accounts")]
        public List<Account> Accounts { get; set; }
        [JsonPropertyName("server_knowledge")]
        public int ServerKnowledge { get; set; }

        public static bool operator ==(AccountData left, AccountData right) =>
            Equals(left, right);

        public static bool operator !=(AccountData left, AccountData right) =>
            !Equals(left, right);

        public bool Equals([AllowNull] AccountData other) =>
            Accounts.SequenceEqual(other.Accounts) && 
            ServerKnowledge.Equals(other.ServerKnowledge);

        public override bool Equals(object obj) =>
            (obj is AccountData accountData) && Equals(accountData);

        public override int GetHashCode() =>
            HashCode.Combine(Accounts, ServerKnowledge);
    }
}