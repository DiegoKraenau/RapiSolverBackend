using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Service.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Service.Handler
{
    public class UnregisterServiceHandler : IRequestHandler<UnregisterService, Boolean>
    {
        private readonly IServiceRepository serviceRepository;

        public UnregisterServiceHandler(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
        public Task<bool> Handle(UnregisterService request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return serviceRepository.UnregisterService(request.Id);
            });
        }
    }
}
