using Microsoft.EntityFrameworkCore;
using ProjetoLoja.API.Models;

namespace ProjetoLoja.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Loja> Lojas { get; set; }
    }
}