using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace RapiSolver.Infrastructure.Mediatr.Reservation.Command
{
    public class RegisterReservation : IRequest<Boolean>
    {
        public RegisterReservation(RapiSolver.Core.Entities.Reservation entity)
        {
            Reservation = entity;
        }

        public RapiSolver.Core.Entities.Reservation Reservation;
    }
}
