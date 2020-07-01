using MediatR;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Reservation.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Reservation.Handler
{
    public class ShowReservationsByUserHandler : IRequestHandler<ShowReservationsByUser, IEnumerable<ReservationDTO>>
    {
        private readonly IReservationRepository reservationRepository;

        public ShowReservationsByUserHandler(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public Task<IEnumerable<ReservationDTO>> Handle(ShowReservationsByUser request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return reservationRepository.ShowReservationsByUser(request.Id);
            });
        }
    }
}
