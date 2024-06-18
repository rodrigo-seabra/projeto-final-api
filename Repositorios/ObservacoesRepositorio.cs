using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Repositorios
{
    public class ObservacoesRepositorio: IObservacoesRepositorio
    {
        private readonly Contexto _dbContext;

        public ObservacoesRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteObs(int id)
        {
            ObservacoesModel obs = await GetById(id);
            if (obs == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Observacoes.Remove(obs);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ObservacoesModel>> GetAll()
        {
            return await _dbContext.Observacoes.ToListAsync();
        }

        public async Task<ObservacoesModel> GetById(int id)
        {
            return await _dbContext.Observacoes.FirstOrDefaultAsync(x => x.ObservacoesId == id);
        }

        public async Task<List<ObservacoesModel>> GetByObjectId(int ObjId)
        {
            return await _dbContext.Observacoes.Where(x => x.ObjetoId == ObjId).ToListAsync();
        }

        public async Task<ObservacoesModel> InsertObs(ObservacoesModel observacao)
        {
            await _dbContext.Observacoes.AddAsync(observacao);
            await _dbContext.SaveChangesAsync();
            return observacao;
        }

        public async Task<ObservacoesModel> UpdateObs(ObservacoesModel observacao, int id)
        {
            ObservacoesModel observacoes = await GetById(id);
            if (observacoes == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                observacoes.ObservacoesDescricao = observacao.ObservacoesDescricao;
                observacoes.ObservacaoLocal = observacao.ObservacaoLocal;
                observacoes.ObservacoesData = observacao.ObservacoesData;
                observacoes.UsuarioId = observacao.UsuarioId;
                observacoes.ObjetoId = observacao.ObjetoId;
                _dbContext.Observacoes.Update(observacoes);
                await _dbContext.SaveChangesAsync();
            }
            return observacoes;
        }

    
    }
}
