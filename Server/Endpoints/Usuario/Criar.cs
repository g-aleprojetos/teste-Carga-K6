using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Endpoints.Usuario.request;
using Server.Entities;
using Server.Services.Interfaces;
using System.Threading.Tasks;

namespace Server.Endpoints.UsuarioForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class Criar : ControllerBase
    {
        private IUsuarioService _usuarioService;
        public Criar(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> CriarUsuario(NovoUsuario usuario)
        {
            try
            {
                await _usuarioService.CreateUsuario(usuario);
                return CreatedAtRoute(nameof(_usuarioService.GetUsuario), new { id = usuario.Id, usuario.Senha }, usuario);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}


