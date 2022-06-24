using eAuditoria.Domain.Models;

namespace eAuditoria.Application.Common.Repositories
{
    public interface ILocacaoRepository
    {
        Task<List<Locacao>> GetAllAsync();
        Task<Locacao> GetByIdAsync(int clienteId);
        Task AddAsync(Locacao cliente);
        Task UpdateAsync(Locacao cliente);
        Task DeleteAsync(Locacao cliente);
        Task<List<Cliente>> GetClientesLocacaoAtrasada();
        Task<List<Filme>> GetFilmesSemLocacao();
        Task<List<Filme>> GetTop5FilmesAno();
        Task<List<Filme>> GetBttom3FilmesSemana();
        Task<Cliente> GetSegundoMelhorCliente();
    }
}
