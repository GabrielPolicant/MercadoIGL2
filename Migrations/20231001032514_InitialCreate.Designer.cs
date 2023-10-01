﻿// <auto-generated />
using MercadoIGL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MercadoIGL.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20231001032514_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MercadoIGL.Models.Cargo", b =>
                {
                    b.Property<int>("Id_Cargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Cargo"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<float>("Salario")
                        .HasColumnType("real");

                    b.HasKey("Id_Cargo");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("MercadoIGL.Models.Cliente", b =>
                {
                    b.Property<int>("CPF")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CPF"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome_Cliente")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("CPF");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MercadoIGL.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id_CNPJ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_CNPJ"));

                    b.Property<string>("Cidade")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Razaosocial")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.HasKey("Id_CNPJ");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("MercadoIGL.Models.Funcionario", b =>
                {
                    b.Property<int>("CPF")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CPF"));

                    b.Property<string>("Nome_Completo")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("Senha")
                        .HasColumnType("int");

                    b.Property<int>("cargoID")
                        .HasColumnType("int");

                    b.HasKey("CPF");

                    b.HasIndex("cargoID");

                    b.ToTable("Funcinarios");
                });

            modelBuilder.Entity("MercadoIGL.Models.Produto", b =>
                {
                    b.Property<int>("Id_Produto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Produto"));

                    b.Property<int>("CPF_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("CPF_Funcionario")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<int>("FornecedorCNPJ")
                        .HasColumnType("int");

                    b.Property<int>("Id_Tipo")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id_Produto");

                    b.HasIndex("CPF_Cliente");

                    b.HasIndex("CPF_Funcionario");

                    b.HasIndex("FornecedorCNPJ");

                    b.HasIndex("Id_Tipo");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MercadoIGL.Models.Tipo", b =>
                {
                    b.Property<int>("Id_Tipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Tipo"));

                    b.Property<string>("TipoProduto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_Tipo");

                    b.ToTable("Tipos");
                });

            modelBuilder.Entity("MercadoIGL.Models.Funcionario", b =>
                {
                    b.HasOne("MercadoIGL.Models.Cargo", "cargo")
                        .WithMany()
                        .HasForeignKey("cargoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cargo");
                });

            modelBuilder.Entity("MercadoIGL.Models.Produto", b =>
                {
                    b.HasOne("MercadoIGL.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("CPF_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MercadoIGL.Models.Funcionario", "funcionario")
                        .WithMany()
                        .HasForeignKey("CPF_Funcionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MercadoIGL.Models.Fornecedor", "fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorCNPJ")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MercadoIGL.Models.Tipo", "tipo")
                        .WithMany()
                        .HasForeignKey("Id_Tipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("fornecedor");

                    b.Navigation("funcionario");

                    b.Navigation("tipo");
                });
#pragma warning restore 612, 618
        }
    }
}