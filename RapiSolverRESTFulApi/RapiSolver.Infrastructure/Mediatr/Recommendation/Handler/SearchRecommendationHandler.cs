using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Recommendation.Query;

namespace RapiSolver.Infrastructure.Mediatr.Recommendation.Handler
{
    public class SearchRecommendationHandler : IRequestHandler<SearchRecommendation, RapiSolver.Core.Entities.Recommendation>
    {
        private readonly IRecommendationRepository recommendationRepository;

        public SearchRecommendationHandler(IRecommendationRepository recommendationRepository)
        {
            this.recommendationRepository = recommendationRepository;
        }
        public Task<Core.Entities.Recommendation> Handle(SearchRecommendation request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return recommendationRepository.SearchRecommendation(request.Id);
            });
        }
    }
}
