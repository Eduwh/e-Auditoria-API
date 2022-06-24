using System.ComponentModel.DataAnnotations;

namespace eAuditoria.Application.ViewModels
{
    public class UpdateLocacaoViewModel
    {
        [Required(ErrorMessage = "A data de locação é obrigatória")]        
        public DateTime DataLocacao { get; set; }        
        [Required(ErrorMessage = "A data de devolução é obrigatória")]
        public DateTime DataDevolucao { get; set; }
    }
}
