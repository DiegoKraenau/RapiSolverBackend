using MediatR;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.ServiceDetails.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.ServiceDetails.Handler
{
    public class ShowServicesByNameHandler : IRequestHandler<ShowServicesByName, IEnumerable<ServiceDetailsDTO>>
    {
        private readonly IServiceDetailsRepository serviceDetailsRepository;

        public ShowServicesByNameHandler(IServiceDetailsRepository serviceDetailsRepository)
        {
            this.serviceDetailsRepository = serviceDetailsRepository;
        }
        public Task<IEnumerable<ServiceDetailsDTO>> Handle(ShowServicesByName request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return serviceDetailsRepository.ShowServicesByName(request.Name);
            });
        }
    }
}
