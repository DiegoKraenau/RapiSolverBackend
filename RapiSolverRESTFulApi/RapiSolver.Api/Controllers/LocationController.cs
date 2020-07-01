using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapiSolver.Core.Entities;
using RapiSolver.Infrastructure.Mediatr.Location.Command;
using RapiSolver.Infrastructure.Mediatr.Location.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Api.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
	{
        private readonly IMediator mediator;

        public LocationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> ShowLocations()
        {
            var res = await mediator.Send(new ShowLocations());
            return Ok(
                res
            );
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RegisterLocation([FromBody] Location location)
        {
            var res = await mediator.Send(new RegisterLocation(location));
            return Ok(
                res
            );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> SearchLocation([FromRoute] int id)
        {
            var res = await mediator.Send(new SearchLocation(id));
            return Ok(
                res
            );
        }

    }
}
