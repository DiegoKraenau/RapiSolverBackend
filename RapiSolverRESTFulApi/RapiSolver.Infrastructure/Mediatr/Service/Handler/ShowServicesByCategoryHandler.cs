using MediatR;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Service.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Service.Handler
{
    public class ShowServicesByCategoryHandler : IRequestHandler<ShowServicesByCategory, IEnumerable<ServiceDTO>>
    {
        private readonly IServiceRepository serviceRepository;

        public ShowServicesByCategoryHandler(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
        public Task<IEnumerable<ServiceDTO>> Handle(ShowServicesByCategory request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return serviceRepository.ShowServicesByCategory(request.Name);
            });
        }
    }
}
