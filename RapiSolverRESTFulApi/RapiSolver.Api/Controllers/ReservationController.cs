using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapiSolver.Core.Entities;
using RapiSolver.Infrastructure.Mediatr.Reservation.Command;
using RapiSolver.Infrastructure.Mediatr.Reservation.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RapiSolver.Api.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController: ControllerBase
    {
        private readonly IMediator mediator;

        public ReservationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// It allows  to obtain all reservation that were added
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ShowReservations()
        {
            var res = await mediator.Send(new ShowReservations());
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to add a reservation
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RegisterReservation([FromBody] Reservation reservation)
        {
            var res = await mediator.Send(new RegisterReservation(reservation));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to search a reservation by their corresponding Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> SearchReservation(int id)
        {
            var res = await mediator.Send(new SearchReservation(id));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain all reservation by User
        /// </summary>
        /// <returns></returns>
        [Route("{userId}/user")]
        [HttpGet]
        public async Task<ActionResult> ShowReservationsByUser(int userId)
        {
            var res = await mediator.Send(new ShowReservationsByUser(userId));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows  to delete  a reservation by their corresponding Id
        /// </summary>
        /// <returns></returns> 
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> UnregisterReservation([FromRoute] int id)
        {
            return Ok(
                await mediator.Send(new UnregisterReservation(id))
            );
        }
    }
}
