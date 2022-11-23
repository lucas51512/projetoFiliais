﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using criptowebbcc.Models;

#nullable disable

namespace criptowebbcc.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20221123153932_RelacoesTransacoesCorrigido")]
    partial class RelacoesTransacoesCorrigido
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("criptowebbcc.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<int>("idade")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("criptowebbcc.Models.Filial", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("cidadeFilial")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<int>("estadoFilial")
                        .HasColumnType("int");

                    b.Property<string>("nomeFilial")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("produtoId")
                        .HasColumnType("int");

                    b.Property<int>("transacaoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clienteId");

                    b.HasIndex("produtoId");

                    b.HasIndex("transacaoId");

                    b.ToTable("Filiais");
                });

            modelBuilder.Entity("criptowebbcc.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descricaoProduto")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("nomeProduto")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("criptowebbcc.Models.Transacao", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int>("produtoId")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<string>("tipoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("valor")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("clienteId");

                    b.HasIndex("produtoId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("criptowebbcc.Models.Filial", b =>
                {
                    b.HasOne("criptowebbcc.Models.Cliente", "Cliente")
                        .WithMany("filiais")
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("criptowebbcc.Models.Produto", "Produto")
                        .WithMany("filiais")
                        .HasForeignKey("produtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("criptowebbcc.Models.Transacao", "Transacao")
                        .WithMany()
                        .HasForeignKey("transacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");

                    b.Navigation("Transacao");
                });

            modelBuilder.Entity("criptowebbcc.Models.Transacao", b =>
                {
                    b.HasOne("criptowebbcc.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("criptowebbcc.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("produtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("criptowebbcc.Models.Cliente", b =>
                {
                    b.Navigation("filiais");
                });

            modelBuilder.Entity("criptowebbcc.Models.Produto", b =>
                {
                    b.Navigation("filiais");
                });
#pragma warning restore 612, 618
        }
    }
}