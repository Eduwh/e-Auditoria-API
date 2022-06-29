using eAuditoria.Application.Common.Interfaces;
using eAuditoria.Application.Common.Repositories;
using eAuditoria.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace eAuditoria.Infrastructure.Repositories
{
    internal class LocacaoRepository : ILocacaoRepository
    {
        IApplicationDbContext _context;

        public LocacaoRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Locacao locacao)
        {
            _context.Locacoes.Add(locacao);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Locacao locacao)
        {
            _context.Locacoes.Remove(locacao);
            return _context.SaveChangesAsync();
        }

        public Task<List<Locacao>> GetAllAsync()
        {
            return _context.Locacoes.Include( locacao => locacao.Cliente ).Include( locacao => locacao.Filme ).ToListAsync();
        }

        public Task<Locacao> GetByIdAsync(int locacaoId)
        {
            return _context.Locacoes.FirstOrDefaultAsync(locacao => locacao.Id == locacaoId);
        }

        public Task<List<Cliente>> GetClientesLocacaoAtrasada()
        {
            return _context.Locacoes.Where( locacao => locacao.DataDevolucao < DateTime.Now ).Select( locacao => locacao.Cliente ).Distinct().ToListAsync();
        }

        public Task<List<Filme>> GetFilmesSemLocacao()
        {
            var filmesComLocacao = _context.Locacoes.Select(locacao => locacao.Id_Filme).Distinct().ToList();
            return _context.Filmes.Where(filme => !filmesComLocacao.Contains(filme.Id)).ToListAsync();
        }

        public Task<List<Filme>> GetTop5FilmesAno()
        {
            var top5FilmesAno = _context.Filmes
                .OrderBy( filme => filme.Locacoes.Where(locacao => locacao.DataLocacao >= DateTime.Now.AddYears(-1)).Count() )
                .Take(5)
                .ToListAsync();

            return top5FilmesAno;
        }

        public Task<List<Filme>> GetBttom3FilmesSemana()
        {
            var bottom3FilmesSemana = _context.Filmes
                .OrderByDescending( filme => filme.Locacoes.Where( locacao => locacao.DataLocacao >= DateTime.Now.AddDays(-7) ).Count() )
                .Take(3)
                .ToListAsync();

            return bottom3FilmesSemana;
        }


        public Task UpdateAsync(Locacao locacao)
        {
            _context.Locacoes.Update(locacao);
            return _context.SaveChangesAsync();
        }

        public Task<Cliente> GetSegundoMelhorCliente()
        {
            var segundoMelhorCLiente = _context.Clientes
                .OrderBy(cliente => cliente.Locacoes.Count)
                .Skip(1)
                .FirstOrDefaultAsync();

            return segundoMelhorCLiente;
        }
    }
}
