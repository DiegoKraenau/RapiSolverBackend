using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.Service.Query
{
    public class ShowServicesBySupplier: IRequest<IEnumerable<ServiceDTO>>
    {
        public ShowServicesBySupplier(int id)
        {
            Id = id;
        }

        public int Id;
    }
}
