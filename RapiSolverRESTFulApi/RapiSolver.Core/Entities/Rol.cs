using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Entities
{
    public class Rol
    {
        public int RolId { get; set; }


        public string RolDescription { get; set; }

        public bool Publish { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}
