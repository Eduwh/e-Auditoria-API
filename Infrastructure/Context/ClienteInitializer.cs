using eAuditoria.Api.Data;
using eAuditoria.Domain.Models;
using eAuditoria.Infrastructure.Persistence;
using Newtonsoft.Json;
using System.Text;

namespace eAuditoria.Infrastructure.Context
{
    public class ClienteInitializer
    {
        private readonly ApplicationDbContext _context;

        public ClienteInitializer(ApplicationDbContext context)
            => _context = context;

        public void Initialize()
        {
            if (_context.Clientes.FirstOrDefault() == null)
            {
                var jsonData = File.ReadAllText("JSON/cliente.json", Encoding.UTF8);
                SeedData(jsonData);
            }
        }

        public void SeedData(string jsonData)
        {
            var projects = JsonConvert.DeserializeObject<List<Cliente>>(jsonData);

            foreach (var project in projects)
            {
                _context.Clientes.Add(project);
            }

            _context.SaveChanges();
        }
    }
}
