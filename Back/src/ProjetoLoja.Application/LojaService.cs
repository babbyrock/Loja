using System;
using System.Threading.Tasks;
using ProjetoLoja.Application.Contratos;
using ProjetoLoja.Domain;
using ProjetoLoja.Persistence.Contratos;

namespace ProjetoLoja.Application
{
    public class LojaService : ILojaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ILojaPersist _lojaPersist;
        public LojaService(IGeralPersist geralPersist, ILojaPersist lojaPersist)
        {
            _lojaPersist = lojaPersist;
            _geralPersist = geralPersist;
        }
        public async Task<Loja> AddLoja(Loja model)
        {
            try{
                _geralPersist.Add<Loja>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _lojaPersist.GetLojaByIdAsync(model.Id);
                }
                return null;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

         public async Task<Loja> UpdateLoja(int lojaId, Loja model)
        {
            try
            {
                var loja = await _lojaPersist.GetLojaByIdAsync(lojaId);
                if (loja == null)  return null;

                model.Id = loja.Id;

                _geralPersist.Update(model);

                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _lojaPersist.GetLojaByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteLoja(int lojaId)
        {
            try
            {
                var loja = await _lojaPersist.GetLojaByIdAsync(lojaId);
                if (loja == null)  throw new Exception ("Loja para remover não foi encontrada.");

                _geralPersist.Delete<Loja>(loja);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Loja[]> GetAllLojaAsync()
        {
            try 
            {
                var lojas = await _lojaPersist.GetAllLojaAsync();
                if (lojas == null) return null;

                return lojas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Loja[]> GetAllLojaByNomeFantasiaAsync(string nomeFantasia)
        {
            try 
            {
                var lojas = await _lojaPersist.GetAllLojaByNomeFantasiaAsync(nomeFantasia);
                if (lojas == null) return null;

                return lojas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Loja> GetLojaByIdAsync(int lojaId)
        {
            try 
            {
                var lojas = await _lojaPersist.GetLojaByIdAsync(lojaId);
                if (lojas == null) return null;

                return lojas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}