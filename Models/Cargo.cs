using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Cargos")]
    public class Cargo
    {
        [Key]
        [Display(Name = "ID_Cargo")]
        public int Id_Cargo { get; set; }
        [StringLength(30)]
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Salario")]
        public float Salario { get; set; }

    }
}
