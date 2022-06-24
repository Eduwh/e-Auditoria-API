using eAuditoria.Application.ViewModels;
using eAuditoria.Domain.Models;

namespace eAuditoria.Application.Common.Interfaces
{
    public interface IClienteService
    {        
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync( int clienteId );
        Task AddAsync( EditorClienteViewModel clienteViewModel );
        Task ChangeAsync( Cliente cliente, EditorClienteViewModel clienteViewModel );
        Task DeleteAsync( Cliente cliente );
    }
}
