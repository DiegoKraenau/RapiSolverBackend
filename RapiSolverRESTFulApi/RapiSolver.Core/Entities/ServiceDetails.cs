using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Entities
{
    public class ServiceDetails
    {
        public int ServiceDetailsId { get; set; }

        public Servicio Servicio { get; set; }

        public Supplier Supplier { get; set; }

        public int SupplierId { get; set; }

        public int ServicioId { get; set; }
    }
}
