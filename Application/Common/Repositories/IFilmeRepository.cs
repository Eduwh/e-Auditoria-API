using eAuditoria.Domain.Models;

namespace eAuditoria.Application.Common.Repositories
{
    public interface IFilmeRepository
    {
        Task<List<Filme>> GetAllAsync();
        Task<Filme> GetByIdAsync(int clienteId);
        Task AddAsync(Filme cliente);
        Task UpdateAsync(Filme cliente);
        Task DeleteAsync(Filme cliente);        
    }
}
