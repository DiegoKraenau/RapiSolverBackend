using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Recommendation.Query;

namespace RapiSolver.Infrastructure.Mediatr.Recommendation.Handler
{
    public class ShowRecommendationsBySupplierHandler : IRequestHandler<ShowRecommendationsBySupplier, IEnumerable<RecommendationDTO>>
    {
        private readonly IRecommendationRepository recommendationRepository;

        public ShowRecommendationsBySupplierHandler(IRecommendationRepository recommendationRepository)
        {
            this.recommendationRepository = recommendationRepository;
        }
        public Task<IEnumerable<RecommendationDTO>> Handle(ShowRecommendationsBySupplier request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return recommendationRepository.ShowRecommendationsBySupplier(request.Id);
            });
        }
    }
}
