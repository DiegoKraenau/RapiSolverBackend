using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapiSolver.Core.DTOs;
using RapiSolver.Infrastructure.Mediatr.ServiceDetails.Command;
using RapiSolver.Infrastructure.Mediatr.ServiceDetails.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Api.Controllers
{
    [Route("api/servicedetails")]
    [ApiController]
    public class ServiceDetailsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ServiceDetailsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// It allows  to obtain all  service details from a supplier with a service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ShowServiceDetails()
        {
            var res = await mediator.Send(new ShowServiceDetails());
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to add a service detail  between a supplier with a service
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RegisterServiceDetail([FromBody] ServiceDetailsDTO serviceDetails)
        {
            var res = await mediator.Send(new RegisterServiceDetail(serviceDetails));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain a service detail view model between a supplier with a service by its corresponding Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> SearchServiceDetails([FromRoute] int id)
        {
            var res = await mediator.Send(new SearchServiceDetails(id));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain all  service details by a name of the service
        /// </summary>
        /// <returns></returns>
        [Route("{nombre}/servicios")]
        [HttpGet]
        public async Task<ActionResult> ShowServicesByName(string nombre)
        {
            var res = await mediator.Send(new ShowServicesByName(nombre));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain all  service details by low Cost
        /// </summary>
        /// <returns></returns>
        [Route("lowcost")]
        [HttpGet]
        public async Task<ActionResult> ShowServicesByLowCost()
        {
            var res = await mediator.Send(new ShowServicesByLowCost());
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain all  service details by low Cost and name
        /// </summary>
        /// <returns></returns>
        [Route("{nombre}/lowcost")]
        [HttpGet]
        public async Task<ActionResult> Get4(string nombre)
        {
            var res = await mediator.Send(new ShowServiceByLowCostAndName(nombre));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain only the last  3 service details
        /// </summary>
        /// <returns></returns>
        [HttpGet("obtainonlythree")]
        public async Task<ActionResult> ShowLastServicesDetails()
        {
            var res = await mediator.Send(new ShowLastServicesDetails());
            return Ok(
                res
            );
        }

    }
}
