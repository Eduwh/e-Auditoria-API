using eAuditoria.Application.Common.Interfaces;
using eAuditoria.Application.Common.Repositories;
using eAuditoria.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace eAuditoria.Infrastructure.Repositories
{
    internal class ClienteRepository : IClienteRepository
    {
        IApplicationDbContext _context;

        public ClienteRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            return _context.SaveChangesAsync();
        }

        public Task<List<Cliente>> GetAllAsync()
        {
            return _context.Clientes.ToListAsync();
        }

        public Task<Cliente> GetByIdAsync(int clienteId)
        {
            return _context.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == clienteId);
        }

        public Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            return _context.SaveChangesAsync();
        }
    }
}
