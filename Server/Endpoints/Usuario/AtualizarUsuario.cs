using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Endpoints.UsuarioForm.request;
using Server.Entities;
using Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Server.Endpoints.UsuarioForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtualizarUsuario : ControllerBase
    {
        private IRepository _repository;
        public AtualizarUsuario(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPut("/Usuario/id:Guid")]
        [SwaggerOperation(
         Summary = "Atualiza Usuario",
         Description = "Atualiza Usuario",
         OperationId = "Usuario.AtualizaUsuario",
         Tags = new[] { "UsuarioEndpoints" })
         ]
        public async Task<ActionResult> Atualizar(UsuarioRequest request)
        {
            try
            {
                var usuario = await _repository.GetByIdAsync<Usuario>(request.Id);
                if (usuario == null)return NotFound($"Não foi encontrado o usuario do id= {request.Id}");

                usuario.AtualizarUsuario(request.Nome, request.Senha);
                await _repository.UpdateAsync(usuario);
                return Ok();
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}

