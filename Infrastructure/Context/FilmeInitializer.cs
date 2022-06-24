using eAuditoria.Api.Data;
using eAuditoria.Domain.Models;
using eAuditoria.Infrastructure.Persistence;
using Newtonsoft.Json;
using System.Text;

namespace eAuditoria.Infrastructure.Context
{
    public class FilmeInitializer
    {
        private readonly ApplicationDbContext _context;

        public FilmeInitializer(ApplicationDbContext context)
            => _context = context;

        public void Initialize()
        {
            if (_context.Filmes.FirstOrDefault() == null)
            {
                var jsonData = File.ReadAllText("JSON/filme.json", Encoding.UTF8);
                SeedData(jsonData);
            }
        }

        public void SeedData(string jsonData)
        {
            var projects = JsonConvert.DeserializeObject<List<Filme>>(jsonData);

            foreach (var project in projects)
            {
                _context.Filmes.Add(project);
            }

            _context.SaveChanges();
        }
    }
}
