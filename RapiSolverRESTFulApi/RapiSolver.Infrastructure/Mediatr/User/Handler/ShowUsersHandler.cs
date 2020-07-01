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
    public class ShowUsersHandler: IRequestHandler<ShowUsers,IEnumerable<UsuarioDTO>>
    {
        private readonly IUsuarioRepository usuarioRepository;

        public ShowUsersHandler(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Task<IEnumerable<UsuarioDTO>> Handle(ShowUsers request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return usuarioRepository.ShowUsers();
            });
        }
    }
}
