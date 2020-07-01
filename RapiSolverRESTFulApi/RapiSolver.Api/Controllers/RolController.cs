using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Rol.Command;
using RapiSolver.Infrastructure.Mediatr.Rol.Handler;
using RapiSolver.Infrastructure.Mediatr.Rol.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Api.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolController:ControllerBase
    {


        private readonly IMediator mediator;

        public RolController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        /// <summary>
        /// It allows to obtain all the roles 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ShowRoles()
        {
            var roles = await mediator.Send(new ShowRoles());
            return Ok(
                roles
            );
        }

        /// <summary>
        /// It allows  to delete  a role by their corresponding Id
        /// </summary>
        /// <returns></returns>       
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> UnregisterRol([FromRoute] int id)
        {

            return Ok(
                await mediator.Send(new UnregisterRol(id))
            ) ;
        }


        /// <summary>
        /// It allows  to search for a role by their corresponding Id
        /// </summary>
        /// <returns></returns>       
        [HttpGet("{id}")]
        public async Task<ActionResult> SearchRol([FromRoute] int id)
        {
            var res = await mediator.Send(new SearchRol(id));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to add a role
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RegisterRol([FromBody] RapiSolver.Core.Entities.Rol rol)
        {
            var res = await mediator.Send(new RegisterRol(rol));
            return Ok(
                res
            );
        }
    }
}
