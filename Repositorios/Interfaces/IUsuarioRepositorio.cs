using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetAll();

        Task<UsuarioModel> GetById(int id);
        Task<UsuarioModel> GetByEmail(string email);
        Task<UsuarioModel> InsertUser(UsuarioModel usuario);

        Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id);

        Task<bool> DeleteUser(int id);
    }
}
