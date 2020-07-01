using MediatR;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.User.Query
{
    public class SearchUser: IRequest<Usuario>
    {
        public SearchUser(int id)
        {
            Id = id;
        }
        public int Id;
    }
}
