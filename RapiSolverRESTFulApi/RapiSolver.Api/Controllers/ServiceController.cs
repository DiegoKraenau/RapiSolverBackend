using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using RapiSolver.Infrastructure.Mediatr.Service.Command;
using RapiSolver.Infrastructure.Mediatr.Service.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Api.Controllers
{
    [Route("api/servicios")]
    [ApiController]
    public class ServiceController: ControllerBase
    {
        private readonly IMediator mediator;

        public ServiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// It allows to add a service
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RegisterService([FromBody] Servicio service)
        {
            var res = await mediator.Send(new RegisterService(service));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to delete the service by their ID
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> UnregisterService([FromRoute] int id)
        {
            var res = await mediator.Send(new UnregisterService(id));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to update the service by their ID
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateService([FromBody] ServiceDTO serviceDTO)
        {
            var res = await mediator.Send(new UpdateService(serviceDTO));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows  to obtain all  services that were added
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ShowServices()
        {
            var res = await mediator.Send(new ShowServices());
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to search a service by their corresponding Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> SearchService([FromRoute] int id)
        {
            var res = await mediator.Send(new SearchService(id));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain all  service by name of the category
        /// </summary>
        /// <returns></returns>
        [HttpGet("searchByNameCategory/{name}")]
        public async Task<ActionResult> ShowServicesByCategory([FromRoute] string name)
        {
            var res = await mediator.Send(new ShowServicesByCategory(name));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain all service by Supplier
        /// </summary>
        /// <returns></returns>
        [HttpGet("searchBySupplier/{id}")]
        public async Task<ActionResult> ShowServicesBySupplier([FromRoute] int id)
        {
            var res = await mediator.Send(new ShowServicesBySupplier(id));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain all service by user
        /// </summary>
        /// <returns></returns>
        [HttpGet("searchByUser/{id}")]
        public async Task<ActionResult> ShowServicesByUser([FromRoute] int id)
        {
            var res = await mediator.Send(new ShowServicesByUser(id));
            return Ok(
                res
            );
        }
    }
}
