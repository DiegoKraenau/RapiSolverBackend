using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Interfaces
{
    public interface IRecommendationRepository
    {
        Recommendation SearchRecommendation(int id);

        IEnumerable<Recommendation> ShowRecommendations();

        IEnumerable<RecommendationDTO> ShowRecommendationsBySupplier(int id);

        bool RegisterRecommendation(Recommendation entity);
    }
}
