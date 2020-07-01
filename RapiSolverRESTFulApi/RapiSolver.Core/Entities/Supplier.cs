using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Entities
{
    public class Supplier : Persona
    {
        public int SupplierId { get; set; }

        public IEnumerable<ServiceDetails> ServiciosDetails { get; set; }

        public IEnumerable<Recommendation> Recommendations { get; set; }
    }
}
