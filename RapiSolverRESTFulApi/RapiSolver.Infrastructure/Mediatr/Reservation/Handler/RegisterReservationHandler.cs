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
    public class RegisterReservationHandler : IRequestHandler<RegisterReservation, Boolean>
    {
        private readonly IReservationRepository reservationRepository;

        public RegisterReservationHandler(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public Task<bool> Handle(RegisterReservation request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return reservationRepository.RegisterReservation(request.Reservation);
            });
        }
    }
}
