using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetoController: ControllerBase
    {
        private readonly IObjetoRepositorio _objetoRepositorio;

        public ObjetoController(IObjetoRepositorio objetoRepositorio)
        {
            _objetoRepositorio = objetoRepositorio;
        }

        [HttpGet("GetAllObjetos")]
        public async Task<ActionResult<List<ObjetoModel>>> GetAllObjetos()
        {
            List<ObjetoModel> objs = await _objetoRepositorio.GetAll();
            return Ok(objs);
        }


        [HttpGet("GetAllMissingObj")]
        public async Task<ActionResult<List<ObjetoModel>>> GetAllMissingObj()
        {
            List<ObjetoModel> objs = await _objetoRepositorio.GetAllMissingObj();
            if( objs == null)
            {
                return BadRequest(404);
            }
            else
            {
                return Ok(objs);
            }
        }

        [HttpGet("GetAllObjsByUserId/{userId}")]
        public async Task<ActionResult<List<ObjetoModel>>> GetAllByUserId(int userId)
        {
            List<ObjetoModel> objs = await _objetoRepositorio.GetAllObjsByUserId(userId);
            if (objs == null)
            {
                return BadRequest(404);
            }
            else
            {
                return Ok(objs);
            }
        }

        [HttpGet("GetObjetoId/{id}")]
        public async Task<ActionResult<ObjetoModel>> GetObjetoId(int id)
        {
            ObjetoModel obj = await _objetoRepositorio.GetById(id);
            return Ok(obj);
        }

        [HttpPost("CreateObjeto")]
        public async Task<ActionResult<ObjetoModel>> InsertObjeto([FromBody] ObjetoModel objModel)
        {
            ObjetoModel obj = await _objetoRepositorio.InsertObj(objModel);
            return Ok(obj);
        }

        [HttpPut("UpdateObjeto/{id:int}")]
        public async Task<ActionResult<ObjetoModel>> UpdateObjeto(int id, [FromBody] ObjetoModel objModel)
        {
            objModel.ObjetoId = id;
            ObjetoModel obj = await _objetoRepositorio.UpdateObj(objModel, id);
            return Ok(obj);
        }

        [HttpDelete("DeleteObjeto/{id:int}")]
        public async Task<ActionResult<ObjetoModel>> DeleteObjeto(int id)
        {
            bool deleted = await _objetoRepositorio.DeleteObj(id);
            return Ok(deleted);
        }
    }
}
