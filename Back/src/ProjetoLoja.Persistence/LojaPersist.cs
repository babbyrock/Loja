

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Domain;
using ProjetoLoja.Persistence.Context;
using ProjetoLoja.Persistence.Contratos;

namespace ProjetoLoja.Persistence
{
    public class LojaPersist : ILojaPersist
    {
        private readonly ProjetoLojaContext _context;
        public LojaPersist(ProjetoLojaContext context)
        {
            _context = context;
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Loja[]> GetAllLojaAsync()
        {
            IQueryable<Loja> query = _context.Lojas
                .Include(e => e.Funcionarios);                 

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Loja[]> GetAllLojaByNomeFantasiaAsync(string nomeFantasia)
        {
            IQueryable<Loja> query = _context.Lojas
                .Include(e => e.Funcionarios); 

               
            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.NomeFantasia.ToLower().Contains(nomeFantasia.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Loja> GetLojaByIdAsync(int lojaId)
        {
            IQueryable<Loja> query = _context.Lojas
                .Include(e => e.Funcionarios); 

                    

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == lojaId);

            return await query.FirstOrDefaultAsync();
        }
    }
}

