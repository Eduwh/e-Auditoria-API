using eAuditoria.Application.ViewModels;
using eAuditoria.Domain.Models;

namespace eAuditoria.Application.Common.Interfaces
{
    public interface IFilmeService
    {        
        Task<List<Filme>> GetAllAsync();
        Task<Filme> GetByIdAsync( int filmeId );
        Task AddAsync( EditorFilmeViewModel filmeViewModel );
        Task UpdateAsync( Filme filme, EditorFilmeViewModel filmeViewModel );
        Task DeleteAsync( Filme filme );
    }
}
