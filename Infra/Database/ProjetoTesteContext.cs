using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Model.Cadastro;
using ProjetoTeste.Model.Security;
using System.Reflection;

namespace ProjetoTeste.Infra.Database
{
    public class ProjetoTesteContext : DbContext
    {
        public ProjetoTesteContext(DbContextOptions<ProjetoTesteContext> options) : base(options) { }

        public DbSet<Maquina> maquinas { get; set; } // Ajuste conforme suas entidades
        public DbSet<Login> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.HasDefaultSchema("public"); // Use o schema correto do seu banco

            modelBuilder.Entity<Maquina>()
                .ToTable("maquinas") // Define explicitamente a tabela
                .HasKey(m => m.Codigo);

            modelBuilder.Entity<Login>()
                .ToTable("usuarios") // Define explicitamente a tabela
                .HasKey(i => i.Id);
        }
    }
}

