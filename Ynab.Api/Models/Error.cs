using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Ynab.Api.Models
{
    public class Error : IEquatable<Error>
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        public static bool operator ==(Error left, Error right) =>
            Equals(left, right);

        public static bool operator !=(Error left, Error right) =>
            !Equals(left, right);

        public bool Equals([AllowNull] Error other) =>
            (Id, Name, Detail) == (other.Id, other.Name, other.Detail);

        public override bool Equals(object obj) =>
            (obj is Error error) && Equals(error);

        public override int GetHashCode() =>
            HashCode.Combine(Id, Name, Detail);
    }
}