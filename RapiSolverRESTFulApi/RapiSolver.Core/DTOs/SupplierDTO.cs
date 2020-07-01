using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.DTOs
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }


        public int Age { get; set; }
        public string Gender { get; set; }
        public int UsuarioId { get; set; }
        public int LocationId { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
    }
}
