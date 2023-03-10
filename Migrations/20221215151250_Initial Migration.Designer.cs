// <auto-generated />
using ClientesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClientesAPI.Migrations
{
    [DbContext(typeof(ClientesApiDbContext))]
    [Migration("20221215151250_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClientesAPI.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("contatoid")
                        .HasColumnType("integer");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("contatoid");

                    b.ToTable("tb_clientes");
                });

            modelBuilder.Entity("ClientesAPI.Models.Contato", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("tb_contatos");
                });

            modelBuilder.Entity("ClientesAPI.Models.Cliente", b =>
                {
                    b.HasOne("ClientesAPI.Models.Contato", "contato")
                        .WithMany()
                        .HasForeignKey("contatoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("contato");
                });
#pragma warning restore 612, 618
        }
    }
}
