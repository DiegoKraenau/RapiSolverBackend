using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Recommendation.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RapiSolver.Infrastructure.Mediatr.Recommendation.Handler
{
    public class RegisterRecommendationHandler : IRequestHandler<RegisterRecommendation, Boolean>
    {
        private readonly IRecommendationRepository recommendationRepository;

        public RegisterRecommendationHandler(IRecommendationRepository recommendationRepository) 
        {
            this.recommendationRepository = recommendationRepository;
        }
        public Task<Boolean> Handle(RegisterRecommendation request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return recommendationRepository.RegisterRecommendation(request.Recommendation);
            });
        }
    }
}
