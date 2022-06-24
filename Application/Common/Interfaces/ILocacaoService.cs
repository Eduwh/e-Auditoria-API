using eAuditoria.Application.ViewModels;
using eAuditoria.Domain.Models;

namespace eAuditoria.Application.Common.Interfaces
{
    public interface ILocacaoService
    {        
        Task<List<Locacao>> GetAllAsync();
        Task<Locacao> GetByIdAsync( int locacaoId );
        Task AddAsync( CreateLocacaoViewModel locacaoViewModel, Filme filme );
        Task UpdateAsync(Locacao locacao, UpdateLocacaoViewModel locacaoViewModel );
        Task DeleteAsync(Locacao locacao );
        Task<List<Cliente>> GetClientesLocacaoAtrasada();
        Task<List<Filme>> GetFilmesSemLocacao();
        Task<List<Filme>> GetTop5FilmesAno();
        Task<List<Filme>> GetBttom3FilmesSemana();
        Task<Cliente> GetSegundoMelhorCliente();
    }
}
