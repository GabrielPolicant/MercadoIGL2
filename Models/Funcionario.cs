using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Funcinarios")]
    public class Funcionario
    {
        [Key]
        [Display(Name ="CPF:")]
        public int CPF { get; set; }
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome_Completo:")]
        public string Nome_Completo { get; set; }
        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        [Display(Name = "Senha:")]
        public int Senha { get; set; }
        [Display(Name = "Cargo")]
        public int cargoID { get; set; }
        [ForeignKey("cargoID")]
        public Cargo cargo {get; set;} 
    }
 }

