using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.Rol.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.Rol.Handler
{
    public class RegisterRolHandler : IRequestHandler<RegisterRol,Boolean>
    {
        private readonly IRolRepository rolRepository;

        public RegisterRolHandler(IRolRepository rolRepository)
        {
            this.rolRepository = rolRepository;
        }
        public Task<Boolean> Handle(RegisterRol request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return rolRepository.RegisterRol(request.Rol);
            });
        }
    }
}
