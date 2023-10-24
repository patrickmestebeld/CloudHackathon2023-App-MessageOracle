namespace MessageOracle.Infra.Personal.Interfaces
{
    internal interface IObjectGenerator<T> where T : class
    {
        T Generate(Guid key);
    }
}
