using MediatR;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Service.Command
{
    public class UnregisterService: IRequest<Boolean>
    {
        public UnregisterService(int id)
        {
            Id = id;
        }

        public int Id;
    }
}
