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
    public class ShowLocationsHandler : IRequestHandler<ShowLocations, IEnumerable<RapiSolver.Core.Entities.Location>>
    {
        private readonly ILocationRepository locationRepository;

        public ShowLocationsHandler(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public Task<IEnumerable<Core.Entities.Location>> Handle(ShowLocations request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return locationRepository.ShowLocations();
            });
        }
    }
}
