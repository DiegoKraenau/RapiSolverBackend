using MediatR;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Rol.Command
{
    public class RegisterRol: IRequest<Boolean>
    {
        public RegisterRol(RapiSolver.Core.Entities.Rol rol)
        {
            Rol = rol;
        }

        public RapiSolver.Core.Entities.Rol Rol;
    }
}
