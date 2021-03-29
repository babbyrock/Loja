using System.Threading.Tasks;
using ProjetoLoja.Domain;

namespace ProjetoLoja.Application.Contratos
{
    public interface ILojaService
    {
        Task<Loja> AddLoja(Loja model);
        Task<Loja> UpdateLoja(int lojaId, Loja model);
        Task<bool> DeleteLoja(int lojaId);

        Task<Loja[]> GetAllLojaByNomeFantasiaAsync(string nomeFantasia);
        Task<Loja[]> GetAllLojaAsync();
        Task<Loja> GetLojaByIdAsync(int lojaId);
    }
}