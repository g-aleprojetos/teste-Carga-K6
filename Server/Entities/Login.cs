using System;

namespace Server.Entities
{
    public class Login
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public String Senha { get; set; }
    }
}
