using System;
using System.Collections.Generic;

namespace Server.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public List<Calendario> Calendarios { get; set; }
    }
}
