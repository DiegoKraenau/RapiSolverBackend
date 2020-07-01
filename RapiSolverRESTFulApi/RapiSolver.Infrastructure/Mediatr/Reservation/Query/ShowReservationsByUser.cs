using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace RapiSolver.Infrastructure.Mediatr.Reservation.Query
{
    public class ShowReservationsByUser: IRequest<IEnumerable<ReservationDTO>>
    {
        public ShowReservationsByUser(int id)
        {
            Id = id;
        }

        public int Id;
    }
}
