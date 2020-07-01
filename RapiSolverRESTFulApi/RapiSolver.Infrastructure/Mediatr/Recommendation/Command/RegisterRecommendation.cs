using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace RapiSolver.Infrastructure.Mediatr.Recommendation.Command
{
    public class RegisterRecommendation: IRequest<Boolean>
    {
        public RegisterRecommendation(RapiSolver.Core.Entities.Recommendation entity)
        {
            Recommendation = entity;
        }

        public RapiSolver.Core.Entities.Recommendation Recommendation;

    }
}
