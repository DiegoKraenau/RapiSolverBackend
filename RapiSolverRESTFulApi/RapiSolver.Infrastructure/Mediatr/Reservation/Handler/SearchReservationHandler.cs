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
    public class SearchReservationHandler : IRequestHandler<SearchReservation, RapiSolver.Core.Entities.Reservation>
    {
        private readonly IReservationRepository reservationRepository;

        public SearchReservationHandler(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public Task<Core.Entities.Reservation> Handle(SearchReservation request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return reservationRepository.SearchReservation(request.Id);
            });
        }
    }
}
