using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>> GetUsuario()
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuarios();
                return Ok(usuarios);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("UsuariosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>>
            GetUsuarioPorNome([FromQuery] string usuario)
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuarioPorNome(usuario);
                if (usuarios == null) return NotFound($"Não existe o usuário com o critério {usuario}");
                return Ok(usuarios);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Usuario>> GetUsuario([FromQuery] Guid id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuario(id);
                if (usuario == null) return NotFound($"Não existe o usuário com o id: {id}");
                return Ok(usuario);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

 

        [HttpPut("id:Guid")]
        public async Task<ActionResult> Edit(Guid id, [FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.Id == id)
                {
                    await _usuarioService.UpdateUsuario(usuario);
                    return Ok($"usuario com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("dados iconsistentes");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("id:Guid")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuario(id);
                if (usuario != null)
                {
                    await _usuarioService.DeleteUsuario(usuario);
                    return Ok($"Usuario de id= {id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Usuario com id={id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }


    }
}