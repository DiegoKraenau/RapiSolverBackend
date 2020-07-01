using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Recommendation.Query
{
    public class SearchRecommendation: IRequest<RapiSolver.Core.Entities.Recommendation>
    {
        public SearchRecommendation(int id) 
        {
            Id = id;
        }

        public int Id;
    }
}
