// <auto-generated />
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
    [Migration("20221031175758_Anotacoes_v1")]
    partial class Anotacoes_v1
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
                        .HasMaxLength(40)
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

            modelBuilder.Entity("criptowebbcc.Models.Conta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("clienteid")
                        .HasColumnType("int");

                    b.Property<int>("moedaid")
                        .HasColumnType("int");

                    b.Property<float>("quantidade")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("clienteid");

                    b.HasIndex("moedaid");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("criptowebbcc.Models.Moeda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<float>("compra")
                        .HasColumnType("real");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<float>("venda")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Moedas");
                });

            modelBuilder.Entity("criptowebbcc.Models.Transacao", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("contaid")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int>("operacao")
                        .HasColumnType("int");

                    b.Property<float>("quantidade")
                        .HasColumnType("real");

                    b.Property<float>("valor")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("contaid");

                    b.ToTable("Tansacoes");
                });

            modelBuilder.Entity("criptowebbcc.Models.Conta", b =>
                {
                    b.HasOne("criptowebbcc.Models.Cliente", "cliente")
                        .WithMany("contas")
                        .HasForeignKey("clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("criptowebbcc.Models.Moeda", "moeda")
                        .WithMany("contas")
                        .HasForeignKey("moedaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("moeda");
                });

            modelBuilder.Entity("criptowebbcc.Models.Transacao", b =>
                {
                    b.HasOne("criptowebbcc.Models.Conta", "conta")
                        .WithMany("transacoes")
                        .HasForeignKey("contaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("conta");
                });

            modelBuilder.Entity("criptowebbcc.Models.Cliente", b =>
                {
                    b.Navigation("contas");
                });

            modelBuilder.Entity("criptowebbcc.Models.Conta", b =>
                {
                    b.Navigation("transacoes");
                });

            modelBuilder.Entity("criptowebbcc.Models.Moeda", b =>
                {
                    b.Navigation("contas");
                });
#pragma warning restore 612, 618
        }
    }
}
