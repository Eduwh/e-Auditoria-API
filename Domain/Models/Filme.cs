namespace eAuditoria.Domain.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public int Lancamento { get; set; }

        public List<Locacao> Locacoes { get; set; }
    }
}
