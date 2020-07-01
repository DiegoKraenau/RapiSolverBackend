using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.User.Query
{
    public class ShowUsers: IRequest<IEnumerable<UsuarioDTO>>
    {
    }
}
