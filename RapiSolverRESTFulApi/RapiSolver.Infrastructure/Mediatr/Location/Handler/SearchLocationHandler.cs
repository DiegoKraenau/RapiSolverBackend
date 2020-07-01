using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Location.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Location.Handler
{
    public class SearchLocationHandler : IRequestHandler<SearchLocation, RapiSolver.Core.Entities.Location>
    {
        private readonly ILocationRepository locationRepository;

        public SearchLocationHandler(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public Task<Core.Entities.Location> Handle(SearchLocation request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return locationRepository.SearchLocation(request.Id);
            });
        }
    }
}
