using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public Servicio Servicio { get; set; }

        public int ServicioId { get; set; }

        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }

        public Supplier Supplier { get; set; }

        public int SupplierId { get; set; }

        public string Fecha { get; set; }

        public string Note { get; set; }
    }
}
