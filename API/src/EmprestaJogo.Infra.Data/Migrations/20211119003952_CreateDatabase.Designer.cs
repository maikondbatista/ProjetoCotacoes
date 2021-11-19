﻿// <auto-generated />
using System;
using Cotacoes.Infra.Data.SQLServer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cotacoes.Infra.Data.Migrations
{
    [DbContext(typeof(CotacaoContext))]
    [Migration("20211119003952_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cotacoes.Domain.Entities.Cotacao", b =>
                {
                    b.Property<long>("NumeroCotacao")
                        .HasColumnType("bigint");

                    b.Property<string>("Bairro")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("CNPJComprador")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CNPJFornecedor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DataCotacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEntregaCotacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UF")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("NumeroCotacao");

                    b.ToTable("Cotacao");
                });

            modelBuilder.Entity("Cotacoes.Domain.Entities.CotacaoItem", b =>
                {
                    b.Property<long>("NumeroItem")
                        .HasColumnType("bigint");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Marca")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("NumeroCotacao")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Unidade")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("NumeroItem");

                    b.HasIndex("NumeroCotacao");

                    b.ToTable("CotacaoItem");
                });

            modelBuilder.Entity("Cotacoes.Domain.Entities.CotacaoItem", b =>
                {
                    b.HasOne("Cotacoes.Domain.Entities.Cotacao", "Cotacao")
                        .WithMany("CotacaoItens")
                        .HasForeignKey("NumeroCotacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cotacao");
                });

            modelBuilder.Entity("Cotacoes.Domain.Entities.Cotacao", b =>
                {
                    b.Navigation("CotacaoItens");
                });
#pragma warning restore 612, 618
        }
    }
}
