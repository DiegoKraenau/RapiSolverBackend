using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Reservation.Query
{
    public class SearchReservation: IRequest<RapiSolver.Core.Entities.Reservation>
    {
        public SearchReservation(int id)
        {
            Id = id;
        }

        public int Id;
    }
}
