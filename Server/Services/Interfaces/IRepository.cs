using Server.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(Guid id);
        Task<IEnumerable<Usuario>> GetUsuarioPorNome(string name);
        Task CreateUsuario(Usuario usuario);     
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(Usuario usuario);

        Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity;
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        Task UpdateAsync<T>(T entity) where T : BaseEntity;
        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}


