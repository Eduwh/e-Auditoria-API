using eAuditoria.Application.Common.Interfaces;
using eAuditoria.Application.Common.Repositories;
using eAuditoria.Application.ViewModels;
using eAuditoria.Domain.Models;

namespace Application.Services
{
    public class FilmeService : IFilmeService
    {
        IFilmeRepository _repository;
        public FilmeService(IFilmeRepository repository)
            => _repository = repository;

        public Task AddAsync(EditorFilmeViewModel filmeViewModel)
        {
            var filme = new Filme
            {
                Id = 0,
                Titulo = filmeViewModel.Titulo,
                ClassificacaoIndicativa = filmeViewModel.ClassificacaoIndicativa,
                Lancamento = filmeViewModel.Lancamento
            };

            return _repository.AddAsync(filme);
        }

        public Task UpdateAsync(Filme filme, EditorFilmeViewModel filmeViewModel)
        {
            filme.Titulo = filmeViewModel.Titulo;
            filme.ClassificacaoIndicativa = filmeViewModel.ClassificacaoIndicativa;
            filme.Lancamento = filmeViewModel.Lancamento;

            return _repository.UpdateAsync(filme);
        }

        public Task DeleteAsync(Filme filme)
        {
            return _repository.DeleteAsync(filme);
        }

        public Task<List<Filme>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Filme> GetByIdAsync(int filmeId)
        {
            return _repository.GetByIdAsync(filmeId);
        }
    }
}
