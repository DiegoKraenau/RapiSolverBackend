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
    public class SearchServiceDetailsHandler : IRequestHandler<SearchServiceDetails, IEnumerable<ServiceDetailsDTO>>
    {
        private readonly IServiceDetailsRepository serviceDetailsRepository;

        public SearchServiceDetailsHandler(IServiceDetailsRepository serviceDetailsRepository)
        {
            this.serviceDetailsRepository = serviceDetailsRepository;
        }
        public Task<IEnumerable<ServiceDetailsDTO>> Handle(SearchServiceDetails request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return serviceDetailsRepository.SearchServiceDetails(request.Id);
            });
        }
    }
}
