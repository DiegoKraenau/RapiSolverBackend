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
    public class ShowServicesBySupplierHandler : IRequestHandler<ShowServicesBySupplier, IEnumerable<ServiceDTO>>
    {
        private readonly IServiceRepository serviceRepository;

        public ShowServicesBySupplierHandler(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
        public Task<IEnumerable<ServiceDTO>> Handle(ShowServicesBySupplier request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return serviceRepository.ShowServicesBySupplier(request.Id);
            });
        }
    }
}
