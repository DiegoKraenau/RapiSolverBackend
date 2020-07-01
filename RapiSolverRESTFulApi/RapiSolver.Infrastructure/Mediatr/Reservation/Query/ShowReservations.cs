using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Reservation.Query
{
    public class ShowReservations: IRequest<IEnumerable<RapiSolver.Core.Entities.Reservation>>
    {

    }
}
