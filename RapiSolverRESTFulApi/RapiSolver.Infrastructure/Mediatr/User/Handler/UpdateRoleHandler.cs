using MediatR;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.User.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.User.Handler
{
    public class UpdateRoleHandler:IRequestHandler<UpdateRole,Boolean>
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UpdateRoleHandler(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Task<bool> Handle(UpdateRole request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return usuarioRepository.UpdateRole(request.Id);
            });
        }
    }
}
