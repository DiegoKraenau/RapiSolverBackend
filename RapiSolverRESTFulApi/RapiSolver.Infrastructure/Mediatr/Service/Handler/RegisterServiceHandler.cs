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
    public class RegisterServiceHandler : IRequestHandler<RegisterService, Boolean>
    {

        private readonly IServiceRepository serviceRepository;

        public RegisterServiceHandler(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public Task<bool> Handle(RegisterService request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return serviceRepository.RegisterService(request.Service);
            });
        }
    }
}
