using eAuditoria.Domain.Models;

namespace eAuditoria.Application.Common.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync( int clienteId );
        Task AddAsync( Cliente cliente );
        Task UpdateAsync( Cliente cliente );
        Task DeleteAsync( Cliente cliente );
    }
}
