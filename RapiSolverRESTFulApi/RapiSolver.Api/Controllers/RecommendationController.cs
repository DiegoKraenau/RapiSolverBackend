using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapiSolver.Core.Entities;
using RapiSolver.Infrastructure.Mediatr.Recommendation.Command;
using RapiSolver.Infrastructure.Mediatr.Recommendation.Query;

namespace RapiSolver.Api.Controllers
{
    [Route("api/recommendations")]
    [ApiController]
    public class RecommendationController: ControllerBase
    {
        private readonly IMediator mediator;

        public RecommendationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// It allows  to obtain all recommendation that were added
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ShowRecommendations()
        {
            var res = await mediator.Send(new ShowRecommendations());
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to add a recommendation
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RegisterRecommendation([FromBody] Recommendation recommendation)
        {
            var res = await mediator.Send(new RegisterRecommendation(recommendation));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to search a recommendation by their corresponding Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> SearchRecommendation(int id)
        {
            var res = await mediator.Send(new SearchRecommendation(id));
            return Ok(
                res
            );
        }

        /// <summary>
        /// It allows to obtain all recommendation by Supplier
        /// </summary>
        /// <returns></returns>
        [Route("{supplierId}/supplier")]
        [HttpGet]
        public async Task<ActionResult> ShowRecommendationsBySupplier(int supplierId)
        {
            var res = await mediator.Send(new ShowRecommendationsBySupplier(supplierId));
            return Ok(
                res
            );
        }

    }
}
