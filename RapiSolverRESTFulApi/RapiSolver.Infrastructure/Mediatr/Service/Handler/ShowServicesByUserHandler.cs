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
    public class ShowServicesByUserHandler : IRequestHandler<ShowServicesByUser, IEnumerable<ServiceDTO>>
    {
        private readonly IServiceRepository serviceRepository;

        public ShowServicesByUserHandler(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
        public Task<IEnumerable<ServiceDTO>> Handle(ShowServicesByUser request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return serviceRepository.ShowServicesByUser(request.Id);
            });
        }
    }
}
