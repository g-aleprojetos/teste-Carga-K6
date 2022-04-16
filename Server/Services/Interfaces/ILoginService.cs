using Server.Entities;
using System;
using System.Threading.Tasks;

namespace Server.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Usuario> GetUsuario(Guid id);

    }
}
