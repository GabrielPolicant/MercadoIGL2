using Microsoft.EntityFrameworkCore;

namespace MercadoIGL.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet <Cargo> Cargos { get; set; }
        public DbSet <Cliente> Clientes { get; set;}
        public DbSet <Fornecedor> Fornecedores { get; set; }
        public DbSet <Tipo> Tipos { get; set; }
        public DbSet <Funcionario> Funcionarios { get; set; }
        public DbSet <Produto> Produtos { get; set; }
    }
}
