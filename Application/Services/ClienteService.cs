using eAuditoria.Application.Common.Interfaces;
using eAuditoria.Application.Common.Repositories;
using eAuditoria.Application.ViewModels;
using eAuditoria.Domain.Models;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
            => _repository = repository;

        public Task AddAsync(EditorClienteViewModel clienteViewModel)
        {
            var cliente = new Cliente
            {
                Id = 0,
                Nome = clienteViewModel.Nome,
                CPF = clienteViewModel.CPF,
                DataNascimento = clienteViewModel.DataNascimento
            };

            return _repository.AddAsync(cliente);
        }

        public Task ChangeAsync(Cliente cliente, EditorClienteViewModel clienteViewModel)
        {
            cliente.Nome = clienteViewModel.Nome;
            cliente.CPF = clienteViewModel.CPF;
            cliente.DataNascimento = clienteViewModel.DataNascimento;

            return _repository.UpdateAsync(cliente);
        }

        public Task DeleteAsync(Cliente cliente)
        {
            return _repository.DeleteAsync(cliente);
        }

        public Task<List<Cliente>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Cliente> GetByIdAsync(int clienteId)
        {
            return _repository.GetByIdAsync(clienteId);
        }
    }
}
