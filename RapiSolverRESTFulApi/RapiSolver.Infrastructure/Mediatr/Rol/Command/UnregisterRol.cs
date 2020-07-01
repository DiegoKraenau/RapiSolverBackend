using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Rol.Query
{
    public class UnregisterRol: IRequest<Boolean>
    {
        public UnregisterRol(int id)
        {
            Id = id;
        }

        public int Id;
    }
}
