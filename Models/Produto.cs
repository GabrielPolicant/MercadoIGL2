using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
    public int Id_Produto { get; set; }
        [StringLength(30)]
        [Display(Name = "Descricao:")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo Valor é obrigatório")]
        [Display(Name = "Valor:")]
        public int Valor { get; set;}
        [Required(ErrorMessage = "Campo Estoque é obrigatório")]
        [Display(Name = "Estoque:")]
        public int Estoque { get; set;}
        public int FornecedorCNPJ { get; set;}
        [ForeignKey("FornecedorCNPJ")]
        [Display(Name = "CNPJ: ")]
        public Fornecedor fornecedor { get; set; }
        public int CPF_Cliente { get; set; }
        [ForeignKey("CPF_Cliente")]
        [Display(Name = "Cpf do Cliente ")]
        public Cliente cliente { get; set; }
        public int CPF_Funcionario { get; set; }
        [ForeignKey("CPF_Funcionario")]
        [Display(Name = "Funcionario: ")]
        public Funcionario funcionario { get; set; }
        public int Id_Tipo { get; set; }
        [ForeignKey("Id_Tipo")]
        [Display(Name = "Tipo: ")]
        public Tipo tipo { get; set; }

    }
}
