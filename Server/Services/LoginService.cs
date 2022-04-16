using Server.Context;
using Server.Entities;
using Server.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Server.Services
{
    public class LoginService : ILoginService
    {
        private readonly ApiContext _context;

        public LoginService(ApiContext context)
        {
            _context = context;
        }
        public async Task<Usuario> GetUsuario(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return usuario;
        }
    }
}
