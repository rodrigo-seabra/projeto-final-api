﻿using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usersRepositorio)
        {
            _usuarioRepositorio = usersRepositorio;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsers()
        {
            List<UsuarioModel> users = await _usuarioRepositorio.GetAll();
            return Ok(users);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UsuarioModel>> Login ([FromBody] UsuarioModel userModel)
        {
            UsuarioModel userLogin = await _usuarioRepositorio.GetByEmail(userModel.UsuarioEmail);
            if( userLogin.UsuarioEmail == userModel.UsuarioEmail && userLogin.UsuarioSenha == userModel.UsuarioSenha)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("GetUserId/{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUserId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UsuarioModel>> InsertUser([FromBody] UsuarioModel userModel)
        {
            UsuarioModel user = await _usuarioRepositorio.InsertUser(userModel);
            return Ok(user);
        }

        [HttpPut("UpdateUser/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> UpdateUser(int id, [FromBody] UsuarioModel userModel)
        {
            userModel.UsuarioId = id;
            UsuarioModel user = await _usuarioRepositorio.UpdateUser(userModel, id); //update user  retorna o objeto inteiro atualizado
            return Ok(user);
        }

        [HttpDelete("DeleteUser/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> DeleteUser(int id)
        {
            bool deleted = await _usuarioRepositorio.DeleteUser(id);
            return Ok(deleted);
        }
    }
}