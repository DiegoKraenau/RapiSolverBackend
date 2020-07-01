using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Reservation.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Reservation.Handler
{
    public class ShowReservationsHandler : IRequestHandler<ShowReservations, IEnumerable<RapiSolver.Core.Entities.Reservation>>
    {
        private readonly IReservationRepository reservationRepository;

        public ShowReservationsHandler(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public Task<IEnumerable<Core.Entities.Reservation>> Handle(ShowReservations request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return reservationRepository.ShowReservations();
            });
        }
    }
}
