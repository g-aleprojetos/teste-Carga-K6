﻿using Server.Entities;
using System;

namespace Server.Endpoints.UsuarioForm.Response
{
    public class UsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

    }
}
