using Application.Services;
using eAuditoria.Application.Common.Interfaces;
using eAuditoria.Application.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CurrentWeather.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IFilmeService, FilmeService>();
            services.AddTransient<ILocacaoService, LocacaoService>();

            return services;
        }
    }
}
