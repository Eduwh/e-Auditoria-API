using System.ComponentModel.DataAnnotations;

namespace eAuditoria.Application.ViewModels
{
    public class EditorFilmeViewModel
    {
        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(100, ErrorMessage = "O título deve conter no máximo 100 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "A classificação indicativa é obrigatória")]
        public int ClassificacaoIndicativa { get; set; }
        [Required(ErrorMessage = "O lancamento é obrigatório")]
        public int Lancamento { get; set; }
    }
}
