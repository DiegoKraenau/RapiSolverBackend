using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.User.Command
{
    public class UpdateRole: IRequest<Boolean>
    {
        public UpdateRole(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
