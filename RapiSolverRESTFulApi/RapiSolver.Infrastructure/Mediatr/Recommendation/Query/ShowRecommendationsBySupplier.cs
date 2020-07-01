using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using RapiSolver.Core.DTOs;

namespace RapiSolver.Infrastructure.Mediatr.Recommendation.Query
{
    public class ShowRecommendationsBySupplier: IRequest<IEnumerable<RecommendationDTO>>
    {
        public ShowRecommendationsBySupplier(int id)
        {
            Id = id;
        }

        public int Id;
    }
}
