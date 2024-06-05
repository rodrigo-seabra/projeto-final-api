using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{

    public class ObjetoRepositorio : IObjetoRepositorio
    {
        private readonly Contexto _dbContext;

        public ObjetoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeleteObj(int id)
        {
            ObjetoModel objeto = await GetById(id);
            if (objeto == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Objeto.Remove(objeto);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ObjetoModel>> GetAll()
        {
            return await _dbContext.Objeto.ToListAsync();
        }

        public async Task<ObjetoModel> GetById(int id)
        {
            return await _dbContext.Objeto.FirstOrDefaultAsync(x => x.ObjetoId == id);
        }

        public async Task<ObjetoModel> InsertObj(ObjetoModel objeto)
        {
            await _dbContext.Objeto.AddAsync(objeto);
            await _dbContext.SaveChangesAsync();
            return objeto;
        }

        public async Task<ObjetoModel> UpdateObj(ObjetoModel objeto, int id)
        {
            ObjetoModel objetos = await GetById(id);
            if (objetos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                objetos.ObjetoNome = objeto.ObjetoNome;
                objetos.ObjetoCor = objeto.ObjetoCor;
                objetos.ObjetoFoto = objeto.ObjetoFoto;
                objetos.ObjetoStatus = objeto.ObjetoStatus;
                objetos.ObjetoObservacao = objeto.ObjetoObservacao;
                objetos.UsuarioId = objeto.UsuarioId;
                objetos.ObjetoDtDesaparecimento = objeto.ObjetoDtDesaparecimento;
                objetos.ObjetoLocalDesaparecimento = objeto.ObjetoLocalDesaparecimento;
                objetos.ObjetoDtEncontro = objeto.ObjetoDtEncontro;
                _dbContext.Objeto.Update(objetos);
                await _dbContext.SaveChangesAsync();
            }
            return objetos;
        }
    }
}
