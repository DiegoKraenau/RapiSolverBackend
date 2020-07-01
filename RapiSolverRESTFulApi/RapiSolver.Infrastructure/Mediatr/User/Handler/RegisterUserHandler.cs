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
    public class RegisterUserHandler: IRequestHandler<RegisterUser,Boolean>
    {
        private readonly IUsuarioRepository usuarioRepository;

        public RegisterUserHandler(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Task<bool> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return usuarioRepository.RegisterUser(request.Usuario);
            });
        }
    }
}
