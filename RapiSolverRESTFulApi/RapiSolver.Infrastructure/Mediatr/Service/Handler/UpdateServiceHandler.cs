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
    public class UpdateServiceHandler : IRequestHandler<UpdateService, Boolean>
    {
        private readonly IServiceRepository serviceRepository;

        public UpdateServiceHandler(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
        public Task<bool> Handle(UpdateService request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return serviceRepository.UpdateService(request.ServiceDTO);
            });
        }
    }
}
