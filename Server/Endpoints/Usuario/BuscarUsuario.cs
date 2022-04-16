﻿using Microsoft.AspNetCore.Mvc;
using Server.Endpoints.UsuarioForm.Response;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace Server.Endpoints.UsuarioForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscarUsuario : ControllerBase
    {
        private IRepository _repository;
        public BuscarUsuario(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/Usuario/{id:Guid}")]
        [SwaggerOperation(
         Summary = "Buscar um único Usuario",
         Description = "Buscar um único Usuario",
         OperationId = "Usuario.BuscarUsuario",
         Tags = new[] { "UsuarioEndpoints" })
         ]
        public async Task<ActionResult<Usuario>> GetUsuario(Guid id)
        {
            try
            {
                var usuario = await _repository.GetByIdAsync<Usuario>(id);
                var response = new UsuarioResponse
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Senha = usuario.Senha,
                };

                return Ok(response);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}

