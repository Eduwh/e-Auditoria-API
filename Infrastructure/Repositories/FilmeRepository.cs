using eAuditoria.Application.Common.Interfaces;
using eAuditoria.Application.Common.Repositories;
using eAuditoria.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace eAuditoria.Infrastructure.Repositories
{
    internal class FilmeRepository : IFilmeRepository
    {
        IApplicationDbContext _context;

        public FilmeRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Filme filme)
        {
            _context.Filmes.Add(filme);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Filme filme)
        {
            _context.Filmes.Remove(filme);
            return _context.SaveChangesAsync();
        }

        public Task<List<Filme>> GetAllAsync()
        {
            return _context.Filmes.ToListAsync();
        }

        public Task<Filme> GetByIdAsync(int filmeId)
        {
            return _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == filmeId);
        }

        public Task UpdateAsync(Filme filme)
        {
            _context.Filmes.Update(filme);
            return _context.SaveChangesAsync();
        }
    }
}
