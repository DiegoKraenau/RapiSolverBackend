using MediatR;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Rol.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Rol.Handler
{
    public class ShowRolesHandler : IRequestHandler<ShowRoles, IEnumerable<RapiSolver.Core.Entities.Rol>>
    {

        private readonly IRolRepository rolRepository;
         
        public ShowRolesHandler(IRolRepository rolRepository)
        {
            this.rolRepository = rolRepository;
        }

        public Task<IEnumerable<Core.Entities.Rol>> Handle(ShowRoles request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return rolRepository.ShowRoles();
            });
        }
    }
}
