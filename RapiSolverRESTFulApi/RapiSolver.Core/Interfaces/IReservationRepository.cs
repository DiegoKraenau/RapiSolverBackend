using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Interfaces
{
    public interface IReservationRepository
    {
        bool UnregisterReservation(int id);

        Reservation SearchReservation(int id);

        IEnumerable<Reservation> ShowReservations();

        IEnumerable<ReservationDTO> ShowReservationsByUser(int id);

        bool RegisterReservation(Reservation entity);
    }
}
