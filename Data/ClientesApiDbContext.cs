using ClientesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Data
{
    public class ClientesApiDbContext : DbContext
    {
        public ClientesApiDbContext(DbContextOptions options) : base (options) 
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Contato)
                .WithOne()
                .HasForeignKey<Cliente>(cl => cl.contatoid);
        }
    }
}
