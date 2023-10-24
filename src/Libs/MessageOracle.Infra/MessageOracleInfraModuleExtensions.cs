using MessageOracle.Core.Personal.Interfaces;
using MessageOracle.Infra.Personal.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MessageFlow.Infra
{
    public static class MessageOracleInfraModuleExtensions
    {
        public static IServiceCollection AddInfraModule(this IServiceCollection services)
        {
            services.AddTransient<IPersonalDataGenerator, BogusPersonalDataGenerator>();
            return services;
        }
    }
}
