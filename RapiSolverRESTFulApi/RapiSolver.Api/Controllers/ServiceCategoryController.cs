using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapiSolver.Infrastructure.Mediatr.ServiceCategory.Command;
using RapiSolver.Infrastructure.Mediatr.ServiceCategory.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Api.Controllers
{
    [Route("api/serviceCategory")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public ServiceCategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// It allows to obtain all categories that were added
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ShowCategories()
        {
            var suppliers = await mediator.Send(new ShowCategories());
            return Ok(
                suppliers
            );
        }

        /// <summary>
        /// It allows to obtain a category by Category id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> SearchCategory([FromRoute] int id)
        {
            var res = await mediator.Send(new SearchCategory(id));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to add a category
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RegisterCategory([FromBody] Core.Entities.ServiceCategory entity)
        {
            var res = await mediator.Send(new RegisterCategory(entity));
            return Ok(
                res
            );
        }
    }
}
