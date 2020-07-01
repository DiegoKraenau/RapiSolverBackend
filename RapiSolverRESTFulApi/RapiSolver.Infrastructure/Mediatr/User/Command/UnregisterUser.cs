using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.User.Command
{
    public class UnregisterUser: IRequest<Boolean>
    {
        public UnregisterUser(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
