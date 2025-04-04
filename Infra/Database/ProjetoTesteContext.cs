using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Model;
using ProjetoTeste.Model.Cadastro;
using ProjetoTeste.Model.Security;
using System.Reflection;

namespace ProjetoTeste.Infra.Database
{
    public class ProjetoTesteContext : DbContext
    {
        public ProjetoTesteContext(DbContextOptions<ProjetoTesteContext> options) : base(options) { }

        public DbSet<Maquina> maquinas { get; set; }
        public DbSet<Login> usuarios { get; set; }
        public DbSet<Lancamento> lancamentos { get; set; }
        public DbSet<LancamentoItem> LancamentosItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Maquina>()
                .ToTable("maquinas") // Define explicitamente a tabela
                .HasKey(m => m.Codigo);

            modelBuilder.Entity<Login>()
                .ToTable("usuarios") 
                .HasKey(i => i.Id);

            modelBuilder.Entity<Lancamento>()
                .ToTable("lancamentos") 
                .HasKey(l => l.Codigo);

            modelBuilder.Entity<LancamentoItem>()
                .ToTable("lancamentos_itens")
                .HasKey(li => li.Codigo);
        }
    }
}

