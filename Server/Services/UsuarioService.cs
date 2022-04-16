using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.Entities;
using Server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class UsuarioService : IRepository
    {
        private readonly ApiContext _context;

        public UsuarioService(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioPorNome(string name)
        {
            IEnumerable<Usuario> usuarios;
            if (!string.IsNullOrWhiteSpace(name))
            {
                usuarios = await _context.Usuarios.Where(n => n.Nome.Contains(name)).ToListAsync();
            }
            else
            {
                usuarios = await GetUsuarios();
            }
            return usuarios;
        }

        public async Task<Usuario> GetUsuario(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return usuario;
        }



        public async Task CreateUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuario(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }




        public Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity
        {
            return _context.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            return _context.Set<T>().ToListAsync();
        }
  
        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
