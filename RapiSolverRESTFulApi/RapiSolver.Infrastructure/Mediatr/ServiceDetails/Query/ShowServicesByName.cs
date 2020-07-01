using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.ServiceDetails.Query
{
    public class ShowServicesByName: IRequest<IEnumerable<ServiceDetailsDTO>>
    {
        public ShowServicesByName(string name)
        {
            Name = name;
        }
        public string Name;
    }
}
