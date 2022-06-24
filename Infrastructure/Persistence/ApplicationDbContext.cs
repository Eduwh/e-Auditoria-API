using Microsoft.EntityFrameworkCore;
using eAuditoria.Api.Data.Mappings;
using eAuditoria.Domain.Models;
using eAuditoria.Application.Common.Interfaces;

namespace eAuditoria.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext() : base() { }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            //This makes so there is no need of a UserMap
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new FilmeMap());
            builder.ApplyConfiguration(new LocacaoMap());
        }

        //Replace here with your sqlServer string connection
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer("Server=DESKTOP-MU5JC2T\\MSSQLSERVER02;Database=eLocadora;User ID=eduardo.lucrezia;Password=eduardo4040");
    }
}