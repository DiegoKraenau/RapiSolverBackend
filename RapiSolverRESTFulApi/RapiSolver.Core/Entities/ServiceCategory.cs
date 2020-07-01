using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Entities
{
    public class ServiceCategory
    {
        public int ServiceCategoryId { get; set; }


        public string CategoryName { get; set; }


        public string CategoryDescription { get; set; }

        public List<Servicio> Servicios { get; set; }
    }
}
