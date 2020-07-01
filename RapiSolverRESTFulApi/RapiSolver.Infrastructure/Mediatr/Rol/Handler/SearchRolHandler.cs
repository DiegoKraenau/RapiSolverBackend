using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Rol.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Rol.Handler
{
    public class SearchRolHandler : IRequestHandler<SearchRol, RapiSolver.Core.Entities.Rol>
    {
        private readonly IRolRepository rolRepository;

        public SearchRolHandler(IRolRepository rolRepository)
        {
            this.rolRepository = rolRepository;
        }

        public Task<Core.Entities.Rol> Handle(SearchRol request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return rolRepository.SearchRol(request.Id);
            });
        }
    }
}
