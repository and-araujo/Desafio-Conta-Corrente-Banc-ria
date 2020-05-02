using Banco.App.Extensions;
using Banco.Business.Interfaces;
using Banco.Business.Services;
using Banco.Data.Context;
using Banco.Data.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Banco.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<BancoDbContext>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<IContaCorrenteTransacaoRepository, ContaCorrenteTransacaoRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            //services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
            services.AddScoped<IContaCorrenteTransacaoService, ContaCorrenteTransacaoService>();

            return services;
        }
    }
}
