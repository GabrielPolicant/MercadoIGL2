using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        [Display(Name = "Id_CNPJ")]
        public int Id_CNPJ { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Campo Razao Social é obrigatório")]
        [Display(Name = "Razao Social")]
        public string Razaosocial { get; set; }
        [Display(Name = "Telefone")]
        public int Telefone { get; set; }
        [Display(Name = "Cidade")]
        [StringLength(50)]
        public string Cidade { get; set; }

    }
}
