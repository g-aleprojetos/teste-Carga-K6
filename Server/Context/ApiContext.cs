using Microsoft.EntityFrameworkCore;
using Server.Entities;

namespace Server.Context
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
            
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Login> Logins { get; set; }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(p => p.Nome)
                .HasMaxLength(255);
            modelBuilder.Entity<Usuario>()
                .Property(p => p.Senha)
                .HasMaxLength(16);
        }

    }
}
