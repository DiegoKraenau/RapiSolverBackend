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
    public class ShowServicesByLowCostHandler : IRequestHandler<ShowServicesByLowCost, IEnumerable<ServiceDetailsDTO>>
    {
        private readonly IServiceDetailsRepository serviceDetailsRepository;

        public ShowServicesByLowCostHandler(IServiceDetailsRepository serviceDetailsRepository)
        {
            this.serviceDetailsRepository = serviceDetailsRepository;
        }

        public Task<IEnumerable<ServiceDetailsDTO>> Handle(ShowServicesByLowCost request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return serviceDetailsRepository.ShowServicesByLowCost();
            });
        }
    }
}
