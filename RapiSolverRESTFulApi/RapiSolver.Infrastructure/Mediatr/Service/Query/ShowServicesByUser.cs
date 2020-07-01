using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Service.Query
{
    public class ShowServicesByUser: IRequest<IEnumerable<ServiceDTO>>
    {
        public ShowServicesByUser(int id)
        {
            Id = id;
        }

        public int Id;
    }
}
