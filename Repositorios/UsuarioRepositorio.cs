using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _dbContext;

        public UsuarioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeleteUser(int id)
        {
            UsuarioModel users = await GetById(id);
            if (users == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Usuario.Remove(users);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuario.ToListAsync();

        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<UsuarioModel> GetByEmail(string email)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioEmail == email);
        }

        public async Task<UsuarioModel> InsertUser(UsuarioModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarios = await GetById(id);
            if (usuarios == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                usuarios.UsuarioNome = usuario.UsuarioNome;
                usuarios.UsuarioSenha = usuario.UsuarioSenha;
                usuarios.UsuarioEmail = usuario.UsuarioEmail;
                usuarios.UsuarioTelefone = usuario.UsuarioTelefone;
                _dbContext.Usuario.Update(usuarios);
                await _dbContext.SaveChangesAsync();
            }
            return usuarios;
        }
    }
}
