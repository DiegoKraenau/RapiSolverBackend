using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.ServiceDetails.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.ServiceDetails.Handler
{
    public class RegisterServiceDetailHandler : IRequestHandler<RegisterServiceDetail, bool>
    {
        private readonly IServiceDetailsRepository serviceDetailsRepository;

        public RegisterServiceDetailHandler(IServiceDetailsRepository serviceDetailsRepository)
        {
            this.serviceDetailsRepository = serviceDetailsRepository;
        }
        public Task<bool> Handle(RegisterServiceDetail request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return serviceDetailsRepository.RegisterServiceDetail(request.Entity);
            });
        }
    }
}
