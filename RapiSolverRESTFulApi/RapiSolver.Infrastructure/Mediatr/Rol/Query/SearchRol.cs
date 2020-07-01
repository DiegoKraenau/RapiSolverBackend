using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Rol.Query
{
    public class SearchRol: IRequest<RapiSolver.Core.Entities.Rol>
    {
        public SearchRol(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
