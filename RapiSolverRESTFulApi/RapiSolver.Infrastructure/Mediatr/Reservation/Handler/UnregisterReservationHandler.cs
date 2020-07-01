using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Reservation.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Reservation.Handler
{
    public class UnregisterReservationHandler : IRequestHandler<UnregisterReservation, Boolean>
    {
        private readonly IReservationRepository reservationRepository;

        public UnregisterReservationHandler(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public Task<bool> Handle(UnregisterReservation request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return reservationRepository.UnregisterReservation(request.Id);
            });
        }
    }
}
