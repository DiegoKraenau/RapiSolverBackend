using MediatR;
using RapiSolver.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Infrastructure.Mediatr.ServiceDetails.Query
{
    public class ShowServiceByLowCostAndName: IRequest<IEnumerable<ServiceDetailsDTO>>
    {
        public ShowServiceByLowCostAndName(string name)
        {
            Name = name;
        }
        public string Name;
    }
}
