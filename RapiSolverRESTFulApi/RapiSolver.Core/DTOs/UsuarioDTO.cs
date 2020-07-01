using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.DTOs
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }


        public string UserName { get; set; }


        public string UserPassword { get; set; }

        public int RolId { get; set; }
    }
}
