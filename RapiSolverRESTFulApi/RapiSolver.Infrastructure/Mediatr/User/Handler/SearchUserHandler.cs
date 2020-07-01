using MediatR;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Mediatr.User.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Mediatr.User.Handler
{
    public class SearchUserHandler : IRequestHandler<SearchUser, Usuario>
    {
        private readonly IUsuarioRepository usuarioRepository;

        public SearchUserHandler(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }


        public Task<Usuario> Handle(SearchUser request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return usuarioRepository.SearchUser(request.Id);
            });
        }
    }
}
