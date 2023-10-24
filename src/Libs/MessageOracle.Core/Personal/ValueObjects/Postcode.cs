using MessageOracle.Shared.CustomGuards;
using MessageOracle.Shared.GuardClauses;

namespace MessageOracle.Core.Personal.ValueObjects;

public class Postcode
{
    public string Value { get; } = "";

    public Postcode(string postcode)
    {
        Guard.Against.InvalidPostcode(postcode);
        Value = postcode;
    }

    public override string ToString() => Value;
    public override bool Equals(object? obj) => obj is Postcode postcode && postcode.Value == Value;
    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator ==(Postcode left, Postcode right) => left.Value == right.Value;
    public static bool operator !=(Postcode left, Postcode right) => left.Value != right.Value;

    public static implicit operator string(Postcode postcode) => postcode.ToString()!;
    public static implicit operator Postcode(string postcode) => new(postcode);
}