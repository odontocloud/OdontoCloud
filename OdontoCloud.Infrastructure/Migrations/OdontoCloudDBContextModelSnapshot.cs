﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OdontoCloud.Infrastructure.Context;

#nullable disable

namespace OdontoCloud.Infrastructure.Migrations
{
    [DbContext(typeof(OdontoCloudDBContext))]
    partial class OdontoCloudDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Anamnese", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Alergia")
                        .HasColumnType("bit");

                    b.Property<bool>("CoagulacaoSangramento")
                        .HasColumnType("bit");

                    b.Property<string>("DescricaoAlergia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoDoencaCardiovascular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoRestricaoMedicamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoTratamentoMedico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Diabetes")
                        .HasColumnType("bit");

                    b.Property<bool>("DoencaCardiovascular")
                        .HasColumnType("bit");

                    b.Property<bool>("DoencaHepatica")
                        .HasColumnType("bit");

                    b.Property<bool>("DoencaRespiratoria")
                        .HasColumnType("bit");

                    b.Property<bool>("Fumante")
                        .HasColumnType("bit");

                    b.Property<bool>("Gravida")
                        .HasColumnType("bit");

                    b.Property<bool>("GravidaAmamentando")
                        .HasColumnType("bit");

                    b.Property<bool>("Hepatite")
                        .HasColumnType("bit");

                    b.Property<bool>("Hipertencao")
                        .HasColumnType("bit");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<bool>("MedicamentoUso")
                        .HasColumnType("bit");

                    b.Property<bool>("Osteoporose")
                        .HasColumnType("bit");

                    b.Property<bool>("ProblemaAnestesia")
                        .HasColumnType("bit");

                    b.Property<bool>("ProblemaGastrico")
                        .HasColumnType("bit");

                    b.Property<bool>("RestricaoMedicamento")
                        .HasColumnType("bit");

                    b.Property<bool>("TratamentoMedico")
                        .HasColumnType("bit");

                    b.HasKey("Id")
                        .HasName("Anamnese_PK");

                    b.HasIndex("IdCliente");

                    b.ToTable("Anamnese", (string)null);
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TempoDuracao")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id")
                        .HasName("Atendimento_PK");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdFuncionario");

                    b.ToTable("Atendimento", (string)null);
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNLE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndicadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profissao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelCelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelResidencial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("Cliente_PK");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.DetalheAtendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdAtendimento")
                        .HasColumnType("int");

                    b.Property<int>("IdItem")
                        .HasColumnType("int");

                    b.Property<float>("QuantidadeItem")
                        .HasColumnType("real");

                    b.HasKey("Id")
                        .HasName("DetalheAtendimento_PK");

                    b.HasIndex("IdAtendimento");

                    b.HasIndex("IdItem");

                    b.ToTable("DetalheAtendimento", (string)null);
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("Endereco_PK");

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelCelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelResidencial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("Fornecedor_PK");

                    b.ToTable("Fornecedor", (string)null);
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salario")
                        .HasColumnType("float");

                    b.Property<string>("TelCelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelResidencial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("Funcionario_PK");

                    b.ToTable("Funcionario", (string)null);
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdFornecedor")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("QuantidadeEstoque")
                        .HasColumnType("float");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.HasKey("Id")
                        .HasName("Item_PK");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Anamnese", b =>
                {
                    b.HasOne("OdontoCloud.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Anamneses")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Atendimento", b =>
                {
                    b.HasOne("OdontoCloud.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Atendimentos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OdontoCloud.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("Atendimentos")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.DetalheAtendimento", b =>
                {
                    b.HasOne("OdontoCloud.Domain.Entities.Atendimento", "Atendimento")
                        .WithMany("DetalheAtendimentos")
                        .HasForeignKey("IdAtendimento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OdontoCloud.Domain.Entities.Item", "Item")
                        .WithMany("DetalheAtendimentos")
                        .HasForeignKey("IdItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atendimento");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Item", b =>
                {
                    b.HasOne("OdontoCloud.Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany("Itens")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Atendimento", b =>
                {
                    b.Navigation("DetalheAtendimentos");
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Anamneses");

                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Fornecedor", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Funcionario", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("OdontoCloud.Domain.Entities.Item", b =>
                {
                    b.Navigation("DetalheAtendimentos");
                });
#pragma warning restore 612, 618
        }
    }
}
