using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public class Usuario: BaseEntity
    {
        public String Nome { get; set; }
        public String Senha { get; set; }
    }
}
