using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Recommendation.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RapiSolver.Infrastructure.Mediatr.Recommendation.Handler
{
    public class ShowRecommendationsHandler : IRequestHandler<ShowRecommendations, IEnumerable<RapiSolver.Core.Entities.Recommendation>>
    {
        private readonly IRecommendationRepository recommendationRepository;

        public ShowRecommendationsHandler(IRecommendationRepository recommendationRepository)
        {
            this.recommendationRepository = recommendationRepository;
        }

        public Task<IEnumerable<Core.Entities.Recommendation>> Handle(ShowRecommendations request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return recommendationRepository.ShowRecommendations();
            });
        }
    }
}
