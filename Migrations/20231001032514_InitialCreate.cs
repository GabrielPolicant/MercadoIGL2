using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercadoIGL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id_Cargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Salario = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id_Cargo);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CPF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Cliente = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id_CNPJ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Razaosocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id_CNPJ);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id_Tipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProduto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id_Tipo);
                });

            migrationBuilder.CreateTable(
                name: "Funcinarios",
                columns: table => new
                {
                    CPF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Completo = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Senha = table.Column<int>(type: "int", nullable: false),
                    cargoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcinarios", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_Funcinarios_Cargos_cargoID",
                        column: x => x.cargoID,
                        principalTable: "Cargos",
                        principalColumn: "Id_Cargo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id_Produto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    FornecedorCNPJ = table.Column<int>(type: "int", nullable: false),
                    CPF_Cliente = table.Column<int>(type: "int", nullable: false),
                    CPF_Funcionario = table.Column<int>(type: "int", nullable: false),
                    Id_Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id_Produto);
                    table.ForeignKey(
                        name: "FK_Produtos_Clientes_CPF_Cliente",
                        column: x => x.CPF_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_FornecedorCNPJ",
                        column: x => x.FornecedorCNPJ,
                        principalTable: "Fornecedores",
                        principalColumn: "Id_CNPJ",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Funcinarios_CPF_Funcionario",
                        column: x => x.CPF_Funcionario,
                        principalTable: "Funcinarios",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Tipos_Id_Tipo",
                        column: x => x.Id_Tipo,
                        principalTable: "Tipos",
                        principalColumn: "Id_Tipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcinarios_cargoID",
                table: "Funcinarios",
                column: "cargoID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CPF_Cliente",
                table: "Produtos",
                column: "CPF_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CPF_Funcionario",
                table: "Produtos",
                column: "CPF_Funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorCNPJ",
                table: "Produtos",
                column: "FornecedorCNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Id_Tipo",
                table: "Produtos",
                column: "Id_Tipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Funcinarios");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
