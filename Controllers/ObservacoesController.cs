using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacoesController: ControllerBase
    {
        private readonly IObservacoesRepositorio _observacoesRepositorio;

        public ObservacoesController(IObservacoesRepositorio observacoesRepositorio)
        {
            _observacoesRepositorio = observacoesRepositorio;
        }

        [HttpGet("GetAllObservacoes")]
        public async Task<ActionResult<List<ObservacoesModel>>> GetAllObservacoes()
        {
            List<ObservacoesModel> obs = await _observacoesRepositorio.GetAll();
            return Ok(obs);
        }

        [HttpGet("GetObservacaoId/{id}")]
        public async Task<ActionResult<ObservacoesModel>> GetObservacaoId(int id)
        {
            ObservacoesModel obs = await _observacoesRepositorio.GetById(id);
            return Ok(obs);
        }

        [HttpGet("GetObservacaoObjetoId/{id}")]
        public async Task<ActionResult<ObservacoesModel>> GetObservacaoObjetoId(int id)
        {
            List<ObservacoesModel> obs = await _observacoesRepositorio.GetByObjectId(id);
            return Ok(obs);
        }


        [HttpPost("CreateObservacao")]
        public async Task<ActionResult<ObservacoesModel>> InsertObservacao([FromBody] ObservacoesModel obsModel)
        {
            ObservacoesModel obs = await _observacoesRepositorio.InsertObs(obsModel);
            return Ok(obs);
        }

        [HttpPut("UpdateObservacao/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> UpdateObjeto(int id, [FromBody] ObservacoesModel obsModel)
        {
            obsModel.ObservacoesId = id;
            ObservacoesModel obs = await _observacoesRepositorio.UpdateObs(obsModel, id);
            return Ok(obs);
        }

        [HttpDelete("DeleteObservacao/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> DeleteObservacao(int id)
        {
            bool deleted = await _observacoesRepositorio.DeleteObs(id);
            return Ok(deleted);
        }
    }
}
