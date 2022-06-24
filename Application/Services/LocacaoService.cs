using eAuditoria.Application.Common.Interfaces;
using eAuditoria.Application.Common.Repositories;
using eAuditoria.Application.ViewModels;
using eAuditoria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LocacaoService : ILocacaoService
    {
        ILocacaoRepository _repository;

        public LocacaoService(ILocacaoRepository locacaoRepository)
        {
            _repository = locacaoRepository;
        }

        public Task AddAsync(CreateLocacaoViewModel locacaoViewModel, Filme filme )
        {
            var locacao = new Locacao
            {
                Id = 0,
                Id_Filme = locacaoViewModel.Id_Filme,
                Id_Cliente = locacaoViewModel.Id_Cliente,
                DataLocacao = locacaoViewModel.DataLocacao,
                DataDevolucao = filme.Lancamento > 0 ? locacaoViewModel.DataLocacao.AddDays(2) : locacaoViewModel.DataLocacao.AddDays(3)
            };

            return _repository.AddAsync(locacao);
        }

        public Task AddAsync(Locacao cliente)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Locacao locacao, UpdateLocacaoViewModel locacaoViewModel)
        {
            locacao.DataLocacao = locacaoViewModel.DataLocacao;
            locacao.DataDevolucao = locacaoViewModel.DataDevolucao;

            return _repository.UpdateAsync(locacao);
        }

        public Task DeleteAsync(Locacao locacao)
        {
            return _repository.DeleteAsync(locacao);
        }

        public Task<List<Locacao>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Locacao> GetByIdAsync(int locacaoId)
        {
            return _repository.GetByIdAsync(locacaoId);
        }

        public Task<List<Cliente>> GetClientesLocacaoAtrasada()
        {
            return _repository.GetClientesLocacaoAtrasada();
        }
        public Task<List<Filme>> GetFilmesSemLocacao()
        {
            return _repository.GetFilmesSemLocacao();
        }

        public Task<List<Filme>> GetTop5FilmesAno()
        {
            return _repository.GetTop5FilmesAno();
        }

        public Task<List<Filme>> GetBttom3FilmesSemana()
        {
            return _repository.GetBttom3FilmesSemana();
        }

        public Task<Cliente> GetSegundoMelhorCliente()
        {
            return _repository.GetSegundoMelhorCliente();
        }
    }
}
