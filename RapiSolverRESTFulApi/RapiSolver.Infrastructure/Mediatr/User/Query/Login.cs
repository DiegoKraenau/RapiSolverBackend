using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.User.Query
{
     public class Login: IRequest<UsuarioDTO>
    {
        public Login(string email,string password)
        {
            Email = email;
            Password = password;
        }

        public string Email;
        public string Password;
    }
}
