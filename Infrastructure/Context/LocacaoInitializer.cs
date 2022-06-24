using eAuditoria.Api.Data;
using eAuditoria.Domain.Models;
using eAuditoria.Infrastructure.Persistence;
using Newtonsoft.Json;
using System.Text;

namespace eAuditoria.Infrastructure.Context
{
    public class LocacaoInitializer
    {
        private readonly ApplicationDbContext _context;

        public LocacaoInitializer(ApplicationDbContext context)
            => _context = context;

        public void Initialize()
        {
            if (_context.Locacoes.FirstOrDefault() == null)
            {
                var jsonData = File.ReadAllText("JSON/locacao.json", Encoding.UTF8);
                SeedData(jsonData);
            }
        }

        public void SeedData(string jsonData)
        {
            var projects = JsonConvert.DeserializeObject<List<Locacao>>(jsonData);

            foreach (var project in projects)
            {
                int lancamento = _context.Filmes.Where(filme => filme.Id == project.Id_Filme).Select(filme => filme.Lancamento).FirstOrDefault();
                project.DataDevolucao = lancamento > 0 ? project.DataLocacao.AddDays(2) : project.DataLocacao.AddDays(3);
                _context.Locacoes.Add(project);
            }

            _context.SaveChanges();
        }
    }
}
