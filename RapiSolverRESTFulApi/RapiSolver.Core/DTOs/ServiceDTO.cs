using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.DTOs
{
    public class ServiceDTO
    {
        public int ServicioId { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public double Cost { get; set; }

        public int ServiceCategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
