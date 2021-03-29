using System.Threading.Tasks;
using ProjetoLoja.Domain;

namespace ProjetoLoja.Persistence.Contratos
{
    public interface ILojaPersist
    {       
        Task<Loja[]> GetAllLojaByNomeFantasiaAsync(string nomeFantasia);
        Task<Loja[]> GetAllLojaAsync();
        Task<Loja> GetLojaByIdAsync(int lojaId);
    }
}