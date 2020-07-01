using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.DTOs
{
    public class ReservationDTO
    {
        public int ReservationId { get; set; }

        public int ServicioId { get; set; }

        public string ServicioName { get; set; }

        public string ServicioCategory { get; set; }

        public int UsuarioId { get; set; }

        public string UsuarioName { get; set; }

        public string UsuarioLastName { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string SupplierLastName { get; set; }

        public string Fecha { get; set; }

        public string Note { get; set; }

        public string NameSolicitante { get; set; }
    }
}
