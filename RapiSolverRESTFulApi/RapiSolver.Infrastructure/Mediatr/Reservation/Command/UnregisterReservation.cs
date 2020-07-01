using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace RapiSolver.Infrastructure.Mediatr.Reservation.Command
{
    public class UnregisterReservation: IRequest<Boolean>
    {
        public UnregisterReservation(int id)
        {
            Id = id;
        }

        public int Id;
    }
}
