using System;

namespace Server.Entities
{
    public class Usuario : BaseEntity
    {
        public String Nome { get; set; }
        public String Senha { get; set; }

        public Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        public void AtualizarUsuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }
    }
}
