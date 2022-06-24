using eAuditoria.Application.Common.Interfaces;
using eAuditoria.Application.Common.Repositories;
using eAuditoria.Infrastructure.Persistence;
using eAuditoria.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CurrentWeather.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Muda a string de conexão aqui
            var connectionString = "Server=DESKTOP-MU5JC2T\\MSSQLSERVER02;Database=eLocadora;User ID=eduardo.lucrezia;Password=eduardo4040";

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            EnsureDatabaseExists(connectionString);

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IFilmeRepository, FilmeRepository>();
            services.AddTransient<ILocacaoRepository, LocacaoRepository>();

            return services;
        }

        private static void EnsureDatabaseExists(string connection)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(connection);

            using var context = new ApplicationDbContext(builder.Options);
            context.Database.EnsureCreated();
        }
    }
}
