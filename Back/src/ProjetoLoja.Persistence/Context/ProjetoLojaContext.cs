using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Domain;

namespace ProjetoLoja.Persistence.Context
{
    public class ProjetoLojaContext : DbContext
    {
        public ProjetoLojaContext(DbContextOptions<ProjetoLojaContext> options) 
        : base(options) { }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loja>()
                        .HasMany(e => e.Funcionarios)
                        .WithOne(rs => rs.Loja)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}