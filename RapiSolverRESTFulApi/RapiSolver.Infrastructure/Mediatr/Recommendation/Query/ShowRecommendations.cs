using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace RapiSolver.Infrastructure.Mediatr.Recommendation.Query
{
    public class ShowRecommendations: IRequest<IEnumerable<RapiSolver.Core.Entities.Recommendation>>
    {

    }
}
