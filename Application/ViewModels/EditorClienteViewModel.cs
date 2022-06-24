using System.ComponentModel.DataAnnotations;

namespace eAuditoria.Application.ViewModels
{
    public class EditorClienteViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(200, ErrorMessage = "O nome deve conter no máximo 200 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 caracteres")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }
    }
}
