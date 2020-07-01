using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Location.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Location.Handler
{
    public class RegisterLocationHandler : IRequestHandler<RegisterLocation, Boolean>
    {
        private readonly ILocationRepository locationRepository;

        public RegisterLocationHandler(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        public Task<Boolean> Handle(RegisterLocation request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return locationRepository.RegisterLocation(request.Location);
            });
        }
    }
}
