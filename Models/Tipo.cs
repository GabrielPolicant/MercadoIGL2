using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Tipos")]
    public class Tipo
    {
        [Key]
        [Display(Name = "Id_Tipo")]
        public int Id_Tipo { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Campo Nome do Tipo é obrigatório")]
        [Display(Name = "Tipo Produto")]
        public string TipoProduto { get; set; }
    }
}
