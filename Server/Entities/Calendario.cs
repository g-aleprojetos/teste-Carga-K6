using System;

namespace Server.Entities
{
    public class Calendario
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Date { get; set; }
    }
}
