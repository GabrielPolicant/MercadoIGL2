using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [Display(Name = "CPF")]
        public int CPF { get; set; }
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome:")]
        public string Nome_Cliente { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Campo Endereco é obrigatório")]
        [Display(Name = "Endereco:")]
        public string Endereco { get; set; }

    }
}
