using MediatR;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Service.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Service.Handler
{
    public class SearchServiceHandler : IRequestHandler<SearchService, Servicio>
    {
        private readonly IServiceRepository serviceRepository;

        public SearchServiceHandler(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
        public Task<Servicio> Handle(SearchService request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return serviceRepository.SearchService(request.Id);
            });
        }
    }
}
