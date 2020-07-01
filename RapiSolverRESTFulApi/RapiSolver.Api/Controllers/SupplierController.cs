using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapiSolver.Infrastructure.Mediatr.Supplier.Command;
using RapiSolver.Infrastructure.Mediatr.Supplier.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Api.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator mediator;

        public SupplierController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// It allows to obtain all suppliers that were added
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ShowSuppliers()
        {
            var suppliers = await mediator.Send(new ShowSuppliers());
            return Ok(
                suppliers
            );
        }

        /// <summary>
        /// It allows to obtain a supplier by Supplier id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> SearchSupplier([FromRoute] int id)
        {
            var res = await mediator.Send(new SearchSupplier(id));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to add a supplier
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RegisterSupplier([FromBody] Core.Entities.Supplier entity)
        {
            var res = await mediator.Send(new RegisterSupplier(entity));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to update the supplier
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateSupplier([FromBody] Core.Entities.Supplier entity)
        {
            var res = await mediator.Send(new UpdateSupplier(entity));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain all  suppliers by last name
        /// </summary>
        /// <returns></returns>
        [Route("{surname}/surname")]
        [HttpGet]
        public async Task<ActionResult> ShowSuppliersBySurname(string surname)
        {
            var suppliers = await mediator.Send(new ShowSuppliersBySurname(surname));
            return Ok(
                suppliers
            );
        }

        /// <summary>
        /// It allows to obtain a supplier by User id
        /// </summary>
        /// <returns></returns>
        [Route("{id}/userid")]
        [HttpGet]
        public async Task<ActionResult> SearchSupplierByUserId(int id)
        {
            var suppliers = await mediator.Send(new SearchSupplierByUserId(id));
            return Ok(
                suppliers
            );
        }

        /// <summary>
        /// It allows to obtain a original supplier by User id
        /// </summary>
        /// <returns></returns>
        [Route("{id}/original")]
        [HttpGet]
        public async Task<ActionResult> SearchOriginalSupplierByUserId(int id)
        {
            var suppliers = await mediator.Send(new SearchOriginalSupplierByUserId(id));
            return Ok(
                suppliers
            );
        }

    }
}
