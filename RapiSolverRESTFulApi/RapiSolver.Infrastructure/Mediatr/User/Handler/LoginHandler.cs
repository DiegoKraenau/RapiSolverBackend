using MediatR;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.User.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.User.Handler
{
    public class LoginHandler: IRequestHandler<Login,UsuarioDTO>
    {
        private readonly IUsuarioRepository usuarioRepository;

        public LoginHandler(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Task<UsuarioDTO> Handle(Login request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return usuarioRepository.Login(request.Email,request.Password);
            });
        }
    }
}
