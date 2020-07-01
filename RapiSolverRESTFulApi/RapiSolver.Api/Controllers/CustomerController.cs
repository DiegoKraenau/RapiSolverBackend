using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapiSolver.Core.Entities;
using RapiSolver.Infrastructure.Mediatr.Customer.Command;
using RapiSolver.Infrastructure.Mediatr.Customer.Query;
using System.Threading.Tasks;

namespace RapiSolver.Api.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController :  ControllerBase
	{
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> ShowCustomers()
        {
            var res = await mediator.Send(new ShowCustomers());
            return Ok(
                res
            );
        }

        [HttpPost]
        public async Task<ActionResult> RegisterCustomer([FromBody] Customer customer)
        {
            var res = await mediator.Send(new RegisterCustomer(customer));
            return Ok(
                res
            );
        }

        [HttpPut("buysubscription/{userid}")]
        [Authorize]
        public async Task<ActionResult> BuySubscription([FromRoute] int userid)
        {
            var res = await mediator.Send(new BuySubscription(userid));
            return Ok(
                res
            );
        }

        [Route("{userid}")]
        [HttpGet]
        public async Task<ActionResult> SearchCustomer(int userid)
        {
            var res = await mediator.Send(new SearchCustomer(userid));
            return Ok(
                res
            );
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            var res = await mediator.Send(new UpdateCustomer(customer));
            return Ok(
                res
            );
        }

    }
}
