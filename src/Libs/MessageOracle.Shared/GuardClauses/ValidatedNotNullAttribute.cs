namespace MessageOracle.Shared.GuardClauses;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class ValidatedNotNullAttribute : Attribute { }