using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Entities
{
    public class Servicio
    {
        public int ServicioId { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public double Cost { get; set; }

        public ServiceCategory ServiceCategory { get; set; }

        public int ServiceCategoryId { get; set; }
    }
}
