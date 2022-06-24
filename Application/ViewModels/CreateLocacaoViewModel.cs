using System.ComponentModel.DataAnnotations;

namespace eAuditoria.Application.ViewModels
{
    public class CreateLocacaoViewModel
    {
        [Required(ErrorMessage = "O cliente é obrigatório")]
        public int Id_Cliente { get; set; }
        [Required(ErrorMessage = "O filme é orbigatírio")]
        public int Id_Filme { get; set; }
        [Required(ErrorMessage = "A data de locação é obrigatória")]
        public DateTime DataLocacao { get; set; }
    }
}
