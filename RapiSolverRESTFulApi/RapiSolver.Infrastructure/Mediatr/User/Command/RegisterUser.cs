using MediatR;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.User.Command
{
    public class RegisterUser: IRequest<Boolean>
    {
        public RegisterUser(Usuario entity)
        {
            Usuario = entity;
        }
        public Usuario Usuario;
    }
}
