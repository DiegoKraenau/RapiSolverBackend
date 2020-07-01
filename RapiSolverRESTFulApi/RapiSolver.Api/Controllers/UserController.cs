using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapiSolver.Core.Entities;
using RapiSolver.Infrastructure.Mediatr.User.Command;
using RapiSolver.Infrastructure.Mediatr.User.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Api.Controllers
{
    [Route("api/rapiusers")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// It allows  to obtain all  users that were added
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ShowUsers()
        {
            var res = await mediator.Send(new ShowUsers());
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to add a user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] Usuario usuario)
        {
            var res = await mediator.Send(new RegisterUser(usuario));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to search a user by their corresponding Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> SearchUser(int id)
        {
            var res = await mediator.Send(new SearchUser(id));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to update the role of  a user by their user ID
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateRole(int id)
        {
            var res = await mediator.Send(new UpdateRole(id));
            return Ok(
                res
            );
        }

    }
}
