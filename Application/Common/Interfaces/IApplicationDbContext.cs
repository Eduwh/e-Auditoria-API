using eAuditoria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAuditoria.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Cliente> Clientes { get; }
        DbSet<Filme> Filmes { get; }
        DbSet<Locacao> Locacoes { get; }
        EntityEntry<T> Add<T>(T entity) where T : class;
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
