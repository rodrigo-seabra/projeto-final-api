using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IObservacoesRepositorio
    {
        Task<List<ObservacoesModel>> GetAll();

        Task<ObservacoesModel> GetById(int id);
        Task<ObservacoesModel> InsertObs(ObservacoesModel observacao);

        Task<ObservacoesModel> UpdateObs(ObservacoesModel observacao, int id);

        Task<bool> DeleteObs(int id);
    }
}
