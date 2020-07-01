using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Entities
{
     public abstract  class Persona
    {
        public string Name { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }


        public int Age { get; set; }


        public string Gender { get; set; }


        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }

        public Location Location { get; set; }

        public int LocationId { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Contraseña { get; set; }
    }
}
