using MediatR;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Rol.Query
{
    public class ShowRoles: IRequest<IEnumerable<RapiSolver.Core.Entities.Rol>>
    {
      
    }
}
