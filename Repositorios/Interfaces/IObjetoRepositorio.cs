using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IObjetoRepositorio
    {
        Task<List<ObjetoModel>> GetAll();
        Task<List<ObjetoModel>> GetAllMissingObj();
       
        Task<ObjetoModel> GetById(int id);
        Task<ObjetoModel> InsertObj(ObjetoModel objeto);

        Task<ObjetoModel> UpdateObj(ObjetoModel objeto, int id);

        Task<bool> DeleteObj(int id);
    }
}
