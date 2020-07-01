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
    public class UnregisterRolHandler : IRequestHandler<UnregisterRol, bool>
    {

        private readonly IRolRepository rolRepository;

        public UnregisterRolHandler(IRolRepository rolRepository)
        {
            this.rolRepository = rolRepository;
        }

        public Task<bool> Handle(UnregisterRol request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return rolRepository.UnregisterRol(request.Id);
            });
        }
    }
}
