using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.DTOs
{
    public class RecommendationDTO
    {
        public int RecommendationId { get; set; }

        public string Note { get; set; }

        public double Mark { get; set; }

        //SUPPLIER
        public int SupplierId { get; set; }

        public string NameSupllier { get; set; }


        public string LastNameSupllier { get; set; }


        public string EmailSupllier { get; set; }
        public int UsuarioId { get; set; }
        public string UserName { get; set; }
    }
}
